            using (P.WordprocessingDocument wordDoc =
              P.WordprocessingDocument.Open(@"c:\XYZ.docx", true))
            {
                IEnumerable<OpenXmlElement> elements =
                  wordDoc.MainDocumentPart.Document.Descendants<>(child => child.LocalName == "sdt");
                foreach (OpenXmlElement elem in elements)
                {
                    if (elem.ChildElements.Any(child => child.LocalName == "sdtPr"))
                    {
                        OpenXmlElement sdtPr = elem.ChildElements.FirstOrDefault(child => child.LocalName == "sdtPr");
                        OpenXmlElement l = sdtPr.ChildElements.FirstOrDefault(child => child.LocalName == "lock");
                        if (l == null) //At this point if you have your lock object this isn't null
                        {
                            //Please help here
                            //Please help here
                            //Please help here
                            //Please help here
                        }
                        OpenXmlAttribute valAttribute = l.GetAttribute("val", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
                        if (valAttribute != null) {
                             valAttribute = new OpenXmlAttribute();
                        }
                        if (valAttribute.Value != "sdtContentLocked" && valAttribute.Value != "sdtLocked")
                        {
                            Console.WriteLine("Unlock content element...");
                            valAttribute.Value = "sdtLocked";
                        }
                    }
                }
            } 
