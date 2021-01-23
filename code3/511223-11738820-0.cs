    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Polenter.Serialization;
    
    namespace Test
    {
        public class MySettings
        {
            public string[,] user_credits { get; set; }
    
            public static MySettings Load(string path)
            {
                if (!System.IO.File.Exists(path)) throw new System.ArgumentException("File \"" + path + "\" does not exist.");
                try
                {
                    MySettings result = null;
                    SharpSerializerXmlSettings settings = new SharpSerializerXmlSettings();
                    SharpSerializer serializer = new SharpSerializer(settings);
                    result = (MySettings)serializer.Deserialize(path);
                    return result;
                }
                catch (Exception err)
                {
                    throw new InvalidOperationException(string.Format("Error in MySettings.LoadConfiguration():\r\nMessage:\r\n{0}\r\nStackTrace:\r\n{1}", err.Message, err.StackTrace), err);
                }
            }
    
            public void Save(string targetPath)
            {
                try
                {
                    if (String.IsNullOrEmpty(targetPath))
                        targetPath = GetDefaultPath();
    
                    SharpSerializerXmlSettings settings = new SharpSerializerXmlSettings();
                    SharpSerializer serializer = new SharpSerializer(settings);
    
                    serializer.Serialize(this, targetPath);
                }
                catch (Exception err)
                {
                    throw new InvalidOperationException(string.Format("Error in MySettings.Save(string targetPath):\r\nMessage:\r\n{0}\r\nStackTrace:\r\n{1}", err.Message, err.StackTrace), err);
                }
            }
    
            public static string GetDefaultPath()
            {
                string result = string.Empty;
                try
                {
                    string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                    if (path.StartsWith("file:///"))
                        path = path.Remove(0, "file:///".Length);
                    else if (path.StartsWith("file://"))
                        path = path.Remove(0, "file://".Length);
    
                    path = System.IO.Path.GetDirectoryName(path);
                    return System.IO.Path.Combine(path, "MySettings.xml");
                }
                catch (Exception err)
                {
                     throw new InvalidOperationException(string.Format("Error in MySettings.GetDefaultPath():\r\nMessage:\r\n{0}\r\nStackTrace:\r\n{1}", err.Message, err.StackTrace), err);
                }
            }
        }
    }
