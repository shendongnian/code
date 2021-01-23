    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Xml.Linq;
    using System.Reflection;
    using System.Text;
    namespace WindowsFormsApplication1
    {
        public abstract class Plugin
        {
            public string Type { get; set; }
            public string Message { get; set; }
        }
        public class FilePlugin : Plugin
        {
            public string Path { get; set; }
        }
        public class RegsitryPlugin : Plugin
        {
            public string Key { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }
        static class MyProgram
        {
            [STAThread]
            static void Main(string[] args)
            {
                string xmlstr =@"
                    <Client>
                      <Plugin Type=""FilePlugin"">
                        <Message>i am a file plugin</Message>
                        <Path>c:\</Path>
                      </Plugin>
                      <Plugin Type=""RegsitryPlugin"">
                        <Message>i am a registry plugin</Message>
                        <Key>HKLM\Software\Microsoft</Key>
                        <Name>Version</Name>
                        <Value>3.5</Value>
                      </Plugin>
                    </Client>
                  ";
                Assembly asm = Assembly.GetExecutingAssembly();
                XDocument xDoc = XDocument.Load(new StringReader(xmlstr));
                Plugin[]  plugins = xDoc.Descendants("Plugin")
                    .Select(plugin =>
                    {
                        string typeName = plugin.Attribute("Type").Value;
                        var type = asm.GetTypes().Where(t => t.Name == typeName).First();
                        Plugin p = Activator.CreateInstance(type) as Plugin;
                        p.Type = typeName;
                        foreach (var prop in plugin.Descendants())
                        {
                            type.GetProperty(prop.Name.LocalName).SetValue(p, prop.Value, null);
                        }
                        return p;
                    }).ToArray();
                
                //
                //"plugins" ready to use
                //
            }
        }
    }
