    var xml = new XmlDocument();
        var fragment = @"<tile>
                              <visual>
                                <binding template='TileWideSmallImageAndText02'>
                                  <image id='1' src='http://server/images/{0}_wide.png'/>
                                  <text id='1'>Custom Field : {1}/text>
                                  <text id='2'>Custom Field : {2}</text>
                                  <text id='3'>Custom Field : {3}</text>
                                </binding>
                                <binding template='TileSquarePeekImageAndText01'>
                                  <image id='1' src='http://server/images/{0}_square.png'/>
                                  <text id='1'>Custom Field</text>
                                  <text id='2'>{1}</text>
                                </binding>    
                              </visual>
                            </tile>";
       var returnedXml = SerializeToString(fragment);
       returnedXml = returnedXml.Replace("<string>", "");
       returnedXml = returnedXml.Replace("</string>", "");
        Console.WriteLine(returnedXml);
    }
    public static string SerializeToString(string obj)
    {
        var serializer = new XmlSerializer(obj.GetType());
        var ns = new XmlSerializerNamespaces();
        ns.Add("", "");
        var ms = new MemoryStream();
        //the following line omits the xml declaration
        var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Encoding = new UnicodeEncoding(false, false) };
        var writer = XmlWriter.Create(ms, settings);
        serializer.Serialize(writer, obj, ns);
        return Encoding.Unicode.GetString(ms.ToArray());
    }
