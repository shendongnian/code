    using System.Linq;
    using System.Xml.Linq;
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main ( )
        {
            var xDoc = XElement.Load ( "ApplicationInit.xml" );
            var appSettingsDictionary = (xDoc.Descendants("InputElement")
                .Select ( item => new 
                                 { 
                                     Key = item.Attribute("name").Value,
                                     Value = item.Descendants("id").First().Value 
                                 }
                        )
                    ).ToDictionary ( item => item.Key, item => item.Value );
        }
    }
}
