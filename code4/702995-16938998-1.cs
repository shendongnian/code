    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main(string[] args)
            {
                string input = @"<ScriptFileNames>
                                  <SqlEye>
                                    <ScriptFile Name='_ws_CommandHistory_AllHistory.sql' Type='SP' SqlEyeAnalysisTime='00:00:01.7817594' FxCopAnalysisTime='00:00:00.2253670' FxCopWarningCount='0' SqlEyeWarningCount='2'>
                                          <SqlEyeWarnings>
                                            <SqlEyeWarning message='SD004: Check for existence object then Drop statement before create statement' />
                                            <SqlEyeWarning message='SP001: Set NoCount statement missing or it should be ON.' />
                                          </SqlEyeWarnings>
                                        </ScriptFile>
                                  </SqlEye>
                                </ScriptFileNames>";
    
                XDocument doc = XDocument.Parse(input);
                XmlSerializer serialiser = new XmlSerializer(typeof(ScriptFileNames));
                ScriptFileNames scriptNames = (ScriptFileNames)serialiser.Deserialize(doc.CreateReader());
    
                foreach (SqlEyeWarning warning in scriptNames.SqlEye.ScriptFile.SqlEyeWarnings)
                {
                    Console.WriteLine(scriptNames.SqlEye.ScriptFile.Name + "\t" + warning.Message);
                }
    
                Console.ReadLine();
            }
    
            [XmlRoot]
            public class ScriptFileNames
            {
                [XmlElement("SqlEye")]
                public SqlEye SqlEye { get; set; }
            }
    
            public class SqlEye
            {
                [XmlElement("ScriptFile")]
                public ScriptFile ScriptFile { get; set; }
            }
    
            public class ScriptFile
            {
                [XmlArray("SqlEyeWarnings")]
                [XmlArrayItem("SqlEyeWarning", typeof(SqlEyeWarning))]
                public SqlEyeWarning[] SqlEyeWarnings { get; set; }
    
                [XmlAttribute("Name")]
                public string Name { get; set; }
    
                [XmlAttribute("Type")]
                public string Type { get; set; }
    
                [XmlAttribute("SqlEyeAnalysisTime")]
                public string SqlEyeAnalysisTime { get; set; }
    
                [XmlAttribute("FxCopAnalysisTime")]
                public string FxCopAnalysisTime { get; set; }
    
                [XmlAttribute("FxCopWarningCount")]
                public string FxCopWarningCount { get; set; }
    
                [XmlAttribute("SqlEyeWarningCount")]
                public string SqlEyeWarningCount { get; set; }
            }
    
            public class SqlEyeWarning
            {
                [XmlAttribute("message")]
                public string Message { get; set; }
            }
        }
    }
