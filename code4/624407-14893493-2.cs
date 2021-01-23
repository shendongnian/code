        public static void ExtractPackageObjects(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                RtfReader reader = new RtfReader(sr);
                IEnumerator<RtfObject> enumerator = reader.Read().GetEnumerator();
                while(enumerator.MoveNext())
                {
                    if (enumerator.Current.Text == "object")
                    {
                        if (RtfReader.MoveToNextControlWord(enumerator, "objclass"))
                        {
                            string className = RtfReader.GetNextText(enumerator);
                            if (className == "Package")
                            {
                                if (RtfReader.MoveToNextControlWord(enumerator, "objdata"))
                                {
                                    byte[] data = RtfReader.GetNextTextAsByteArray(enumerator);
                                    using (MemoryStream packageData = new MemoryStream())
                                    {
                                        RtfReader.ExtractObjectData(new MemoryStream(data), packageData);
                                        packageData.Position = 0;
                                        PackagedObject po = PackagedObject.Extract(packageData);
                                        File.WriteAllBytes(po.DisplayName, po.Data);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
