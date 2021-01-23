            /// <summary>
            /// loads and returns the XML file with the given name
            /// </summary>
            /// <param name="modelHesapAdi"> name of the XML file to be returned</param>
            /// <returns>returns the xml of given model hesap adı</returns>
            public static XElement LoadXMLWithGivenModelHesapAdi(string modelHesapAdi, string xmlDirectory)
            {
                XElement modelsXmlFile = XElement.Load(xmlDirectory + modelHesapAdi + ".xml");
    
                return modelsXmlFile;
            }
