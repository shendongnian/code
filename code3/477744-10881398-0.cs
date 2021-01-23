    using(var reader = XmlReader.Create(new FileStream(@"D:\Files\20120604\Data_120604-062516_003.xml", FileMode.Open, FileAccess.Read), new XmlReaderSettings { CloseInput = true, DtdProcessing = DtdProcessing.Ignore, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true }))
                {
                    XmlNodeType nt;
                    do
                    {
                        nt = reader.MoveToContent();
                        if(nt == XmlNodeType.Element) {
                            MessageBox.Show(nt.Name);
                            break;
                        }
                    }
                    while(nt != XmlNodeType.None)
                }
