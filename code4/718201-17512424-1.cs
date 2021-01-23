    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Diagnostics;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Reflection;
     
    namespace Mars.HLSLEditor
    {
        public class ShaderModel {
            public string Key {get; set;}
            public string Name { get; set; }
        }
     
        public class EffectCompiler
        {
            private static Dictionary<string, string> profiles = new Dictionary<string,string>();
     
            public static ObservableCollection<shadermodel> Profiles
            {
                get {
                    var x = from p in profiles select new ShaderModel { Key = p.Key, Name = p.Value};
                    return new ObservableCollection<shadermodel>(x);
                }
            }
     
            public static ShaderModel ProfileByKey(string key) {
                return new ShaderModel { Key = key, Name = profiles[key] };
            }
     
            public static int GetProfileIndex(ShaderModel model) {
                return Array.IndexOf(profiles.Keys.ToArray(), model.Key);
            }
     
            static EffectCompiler() {
     
                profiles.Add("cs_4_0", "Compute Shader model 4.0");
                profiles.Add("cs_4_1", "Compute Shader model 4.1");
                profiles.Add("cs_5_0", "Compute Shader model 5.0");
                profiles.Add("ds_5_0", "Domain Shader model 5.0");
                profiles.Add("fx_2_0", "Effect model 2.0");
                profiles.Add("fx_4_0", "Effect model 4.0");
                profiles.Add("fx_4_1", "Effect model 4.1");
                profiles.Add("fx_5_0", "Effect model 5.0");
     
                profiles.Add("gs_4_0", "Geometry Shader model 4.0");
                profiles.Add("gs_4_1", "Geometry Shader model 4.1");
                profiles.Add("gs_5_0", "Geometry Shader model 5.0");
     
                profiles.Add("hs_5_0", "Hull Shader model 5.0");
     
                profiles.Add("ps_2_0", "Pixel Shader model 2.0");
                profiles.Add("ps_2_a", "Pixel Shader model 2.0 A");
                profiles.Add("ps_2_b", "Pixel Shader model 2.0 B");
                profiles.Add("ps_2_sw", "Pixel Shader model 2.0 (software)");
                profiles.Add("ps_3_0", "Pixel Shader model 3.0");
                profiles.Add("ps_3_sw", "Pixel Shader model 3.0 (software)");
                profiles.Add("ps_4_0", "Pixel Shader model 4.0");
                profiles.Add("ps_4_0_level_9_0", "Pixel Shader model 4.0 (level 9.0)");
                profiles.Add("ps_4_0_level_9_1", "Pixel Shader model 4.0 (level 9.1)");
                profiles.Add("ps_4_0_level_9_3", "Pixel Shader model 4.0 (level 9.3)");
                profiles.Add("ps_4_1", "Pixel Shader model 4.1");
                profiles.Add("ps_5_0", "Pixel Shader model 5.0");
     
                profiles.Add("tx_1_0", "Texture Shader model 1.0 (software)");
     
                profiles.Add("vs_1_1", "Vertex Shader model 1.1");
                profiles.Add("vs_2_0", "Vertex Shader model 2.0");
                profiles.Add("vs_2_a", "Vertex Shader model 2.0 A");
                profiles.Add("vs_2_sw", "Vertex Shader model 2.0 (software)");
                profiles.Add("vs_3_0", "Vertex Shader model 3.0");
                profiles.Add("vs_3_sw", "Vertex Shader model 3.0 (software)");
                profiles.Add("vs_4_0", "Vertex Shader model 4.0");
                profiles.Add("vs_4_0_level_9_0", "Vertex Shader model 4.0 (level 9.0)");
                profiles.Add("vs_4_0_level_9_1", "Vertex Shader model 4.0 (level 9.1)");
                profiles.Add("vs_4_0_level_9_3", "Vertex Shader model 4.0 (level 9.3)");
                profiles.Add("vs_4_1", "Vertex Shader model 4.1");
                profiles.Add("vs_5_0", "Vertex Shader model 5.0");
            }
     
            static object locker = new object();
     
            public static bool TryCompile(string code, ShaderModel model, string entrypoint, out string error) {
     
                lock (locker)
                {
                    string id = Thread.CurrentThread.ManagedThreadId.ToString();
                    string path = string.Format("{0}\\tmp{1}.fx", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), id);
     
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        byte[] data = Encoding.ASCII.GetBytes(code);
                        fs.Write(data, 0, data.Length);
                    }
     
                    string fxc = Path.Combine(new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)).AbsolutePath, @"fxc.exe");
     
                    if (!File.Exists(fxc))
                    {
                        error = "No effect compiler executable!";
                        return false;
                    }
     
                    ProcessStartInfo psi = new ProcessStartInfo(fxc);
                    psi.CreateNoWindow = true;
                    psi.UseShellExecute = false;
                    psi.RedirectStandardError = true;
                    psi.Arguments = string.Format("/T {1} /E {2} /Fo\"{0}.obj\" \"{0}\"", path, model.Key, entrypoint);
     
                    error = string.Empty;
     
                    using (Process p = Process.Start(psi))
                    {
     
                        StreamReader sr = p.StandardError;
                        error = sr.ReadToEnd().Replace(path, "Line ");
     
                        if (!p.WaitForExit(5000))
                        {
                            error = "General failure while compiling (timeout).";
                            return false;
                        }
                    }
     
                    if (File.Exists(path))
                        File.Delete(path);
     
                    if (File.Exists(path + ".obj"))
                    File.Delete(path + ".obj");
     
                    if (error == string.Empty)
                    {
                        return true;
                    }
     
                    error = error.Replace("compilation failed; no code produced", "");
                    error = error.Trim();
     
                    return false;
                }
            }
        }
    }
