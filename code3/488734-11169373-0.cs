    public static void ExportFile(string fileName, string content)
            {
                //THe basis for this code is from http://crmscape.blogspot.com/2009/10/ms-crm-40-sending-attachments-to.html
                byte[] fileContent = Convert.FromBase64String(content);
                using (FileStream file = new FileStream(fileName, FileMode.Create))
                {
    
                    using (BinaryWriter writer = new BinaryWriter(file))
                    {
                        writer.Write(fileContent,0,fileContent.Length);
                        writer.Close();
                    }
    
                    file.Close();
                }
    
            }
