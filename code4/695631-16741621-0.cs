    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    
    namespace SandboxConoleApp
    {
        
        internal class Program
        { 
            private static void Main(string[] args)
            {
                DatabaseRestoreStatus data = null;
                using (var stream = File.Open("test.xml",FileMode.Open))
                {
                    var formatter = new DataContractSerializer(typeof(DatabaseRestoreStatus));
                    data = (DatabaseRestoreStatus)formatter.ReadObject(stream);
                } 
            }
        }
    
        [DataContract(Name = "job-status", Namespace = "http://marklogic.com/xdmp/job-status")]
        public class DatabaseRestoreStatus
        {
            [DataMember(Name = "forest")]
            public Forest Forest { get; set; }
        }
    
        [DataContract(Name = "forest", Namespace = "http://marklogic.com/xdmp/job-status")]
        public class Forest
        {
            [DataMember(Name = "status")]
            public string Status { get; set; }
        }
    }
