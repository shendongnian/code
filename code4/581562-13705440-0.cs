        private static void CreateAltChunksInWordDocument(WordprocessingDocument doc, string externalDocumentPath)
        {
            foreach (var control in doc.ContentControls().ToList()) //Have to do .ToList() on this as when we update the Doc in the loop it stops enumerating otherwise
            {
                SdtProperties props = control.Elements<SdtProperties>().FirstOrDefault();
                if (props == null)
                    continue;
                SdtAlias alias = props.Elements<SdtAlias>().FirstOrDefault();
                if (alias == null || !alias.Val.HasValue || alias.Val.Value != "External Template")
                    continue;
                using (WordprocessingDocument externaldoc = WordprocessingDocument.Open(externalDocumentPath, false))
                {
                    //Replace the Content Control with an AltChunk section, and stream in the external file
                    string altChunkId = "AltChunkId" + Guid.NewGuid().ToString().Replace("{", "").Replace("}", "").Replace("-", "");
                    AlternativeFormatImportPart chunk = doc.MainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                    chunk.FeedData(File.OpenRead(externalDocumentPath));
                    AltChunk altChunk = new AltChunk();
                    altChunk.Id = altChunkId;
                    OpenXmlElement parent = control.Parent;
                    parent.InsertAfter(altChunk, control);
                    control.Remove();
                    XDocument xDocMain;
                    CustomXmlPart partMain = MyCommon.GetMyXmlPart(doc.MainDocumentPart, out xDocMain);
                    XDocument xDocExternal;
                    CustomXmlPart partExternal = MyCommon.GetMyXmlPart(externaldoc.MainDocumentPart, out xDocExternal);
                    if (xDocMain != null && partMain != null && xDocExternal != null && partExternal != null)
                    {
                        MyCommon.MergeXmlPartFields(xDocMain, xDocExternal);
                        //Save the updated part
                        using (Stream outputStream = partMain.GetStream())
                        {
                            using (StreamWriter ts = new StreamWriter(outputStream))
                            {
                                ts.Write(xDocMain.ToString());
                            }
                        }
                    }
                }
            }
        }
