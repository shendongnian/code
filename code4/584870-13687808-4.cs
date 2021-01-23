    using System;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
        private static string SerializeMe(object o)
        {
            XmlSerializer s = new XmlSerializer(o.GetType());
            MemoryStream stream = new MemoryStream();
            XmlWriter writer = new XmlTextWriter(stream, Encoding.Default);
            s.Serialize(writer, o);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return Encoding.Default.GetString(stream.ToArray());
        }
