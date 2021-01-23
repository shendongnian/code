                string rootEndTag = "</AppXmlLogWritter>";
                int rootEndTagLength = Encoding.UTF8.GetBytes(rootEndTag).Length;
                try
                {
                    objMutex.WaitOne();
                    if (!File.Exists(_logFilePath))
                    {
                        File.WriteAllText(_logFilePath, "<?xml version='1.0' encoding='utf-8' standalone='yes'?><AppXmlLogWritter></AppXmlLogWritter>");
                    }
    
                    var fileStream = File.Open(_logFilePath, FileMode.Open);
                    fileStream.Position = fileStream.Length - rootEndTagLength;
    
                    var objStreamWriter = new StreamWriter(fileStream);
                    objStreamWriter.WriteLine(newelement.OuterXml);
                    objStreamWriter.Write(rootEndTag);
                    objStreamWriter.Close();
                    fileStream.Close();
                }
