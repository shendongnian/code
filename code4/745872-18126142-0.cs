    namespace MyApp
    {
        internal class Program
        {
            static Program()
            {
                LoadAssemblyResource.Initialize("MyApp");
            }
            //....
        }
    }  
    namespace MyAppStartup
    { 
        public static class LoadAssemblyResource
        {
            private readonly static String _version_string =
                Assembly.GetExecutingAssembly().GetName().Version.ToString();
            private readonly static String _dll_path = Path.GetTempPath()
                + "\\MyApp\\" + _version_string;
            static public String last_error_msg = null;
            public static bool WriteBytesToFile(string filename, byte[] bytes)
            {
                try
                {
                    var fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Writing file failed. Exception: {0}", e.ToString());
                }
                return false;
            }
            public static Assembly LoadUnsafe(String assembly_name, Byte[] assembly)
            {
                if (!Directory.Exists(_dll_path))
                {
                    Directory.CreateDirectory(_dll_path);
                    Console.WriteLine("Created tmp path '" + _dll_path + "'.");
                }
                String fullpath = _dll_path + "\\" + assembly_name;
                if (!File.Exists(fullpath))
                {
                    Console.WriteLine("Assembly location: " + fullpath + ".");
                    if (!WriteBytesToFile(fullpath, assembly))
                         return null;
                }
    
                return Assembly.UnsafeLoadFrom(fullpath);
            }
            public static void Initialize(String exe_name)
            {
                AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
                {
                    String assembly_name = new AssemblyName(args.Name).Name + ".dll";
                    String resource_name = exe_name + "." + assembly_name;
                    using (var stream = 
                        Assembly.GetExecutingAssembly().GetManifestResourceStream(resource_name))
                    {
                        if (stream == null)
                            return null;
                        Byte[] assembly_data = new Byte[stream.Length];
                        stream.Read(assembly_data, 0, assembly_data.Length);
                        try
                        {
                            Assembly il_assembly = Assembly.Load(assembly_data);
                            return il_assembly;
                        }
                        catch (System.IO.FileLoadException ex)
                        {
                            // might have failed because it's an mixed-mode dll.
                            last_error_msg = ex.Message;
                        }
                        Assembly mixed_mode_assembly = LoadUnsafe(assembly_name, assembly_data);
                        return mixed_mode_assembly;
                    }
                };
            }
        }
}
