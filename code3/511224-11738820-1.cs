    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Polenter.Serialization;
    
    namespace Test
    {
        public class MySettings
        {
            // this is a property we want to serialize along with the settings class.
            // the serializer will automatically recognize it and serialize/deserialize it.
            public string[,] user_credits { get; set; }
            //
            public static MySettings Load(string path)
            {
                if (!System.IO.File.Exists(path)) throw new System.ArgumentException("File \"" + path + "\" does not exist.");
                try
                {
                    MySettings result = null;
                    // the serialization settings are just a needed standard object as long as you don't want to do something special.
                    SharpSerializerXmlSettings settings = new SharpSerializerXmlSettings();
                    // create the serializer.
                    SharpSerializer serializer = new SharpSerializer(settings);
                    // deserialize from File and receive an object containing our deserialized settings, that means: a MySettings Object with every public property in the state that they were saved in.
                    result = (MySettings)serializer.Deserialize(path);
                    // return deserialized settings.
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
                    // if the file isn't there, we can't deserialize.
                    if (String.IsNullOrEmpty(targetPath))
                        targetPath = GetDefaultPath();
    
                    SharpSerializerXmlSettings settings = new SharpSerializerXmlSettings();
                    SharpSerializer serializer = new SharpSerializer(settings);
                    // create a serialized representation of our MySettings instance, and write it to a file.
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
                    // Use Reflection to get the path of the Assembly MySettings is defined in.
                    string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                    // remove the file:// prefix for local files, or file:/// for network/unc paths
                    if (path.StartsWith("file:///"))
                        path = path.Remove(0, "file:///".Length);
                    else if (path.StartsWith("file://"))
                        path = path.Remove(0, "file://".Length);
                    // get the path without filename of the assembly
                    path = System.IO.Path.GetDirectoryName(path);
                    // append default filename "MySettings.xml" as default filename for the settings.
                    return System.IO.Path.Combine(path, "MySettings.xml");
                }
                catch (Exception err)
                {
                     throw new InvalidOperationException(string.Format("Error in MySettings.GetDefaultPath():\r\nMessage:\r\n{0}\r\nStackTrace:\r\n{1}", err.Message, err.StackTrace), err);
                }
            }
        }
        public class Test
        {
           public void Test()
           {
              // create settings for testing
              MySettings settingsTest = new MySettings();
              // save settings to file. You could also pass a path created from a SaveFileDialog, or sth. similar.
              settingsTest.Save(MySettings.GetDefaultPath());
              // Load settings. You could also pass a path created from an OpenFileDialog.
              MySettings anotherTest = MySettings.Load(MySettings.GetDefaultPath());
              // do stuff with the settings.
           }
    }
