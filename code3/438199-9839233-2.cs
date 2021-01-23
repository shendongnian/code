    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var config = new Config
                {
                    Email = new Email
                    {
                        Recipient = "sadh",
                        ServerPort = 23,
                        Username = "lkms",
                        Password = "kmkdvm"
                    },
                    Program = new Programs
                    {
                        Filename = "kmkdvmMerlinAlarm.exe",
                        Filepath = @"D:\Merlin\Initsys\Merlin\Bin\MerlinAlarm.exe"
                    },
                    Database = new Database
                    {
                        serialId = "1"
                    }
                };
    
                XmlSerializer serializer = new XmlSerializer(typeof(Config));
    
                var textWriter = new StreamWriter(@"C:\config.xml");
                serializer.Serialize(textWriter, config);
                textWriter.Close();
    
                Console.Read();
            }
        }
    
        #region [Classes]
    
        public class Config
        {
            [XmlElement("email-settings")]
            public Email Email { get; set; }
    
            public Programs Program { get; set; }
    
            [XmlElement("database-settings")]
            public Database Database { get; set; }
        }
    
        public class Email
        {
            public string Recipient { get; set; }
    
            [XmlElement("Server-port")]
            public int ServerPort { get; set; }
    
            public string Username { get; set; }
            public string Password { get; set; }
        }
    
        public class Programs
        {
            public string Filename { get; set; }
    
            public string Filepath { get; set; }
        }
    
        public class Database
        {
            public string serialId { get; set; }
        }
    
        #endregion
    }
