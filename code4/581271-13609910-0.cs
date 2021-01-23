                        fileAttachment.Load();
                        filecontent = fileAttachment.Content;
                        System.Text.Encoding enc = System.Text.Encoding.ASCII;
                        string strFileContent = enc.GetString(filecontent);
                        Console.WriteLine(strFileContent);
