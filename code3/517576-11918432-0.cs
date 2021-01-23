                //FileStream file = new FileStream(@"C:\bd_sites\ttgme\wwwroot\Evidence\{" + ed.LearnerID + @"}\" + ed.EvidenceFileName, FileMode.Create, System.IO.FileAccess.Write);
                //byte[] bytes = new byte[ms.Length];
                ////ms.Read(buffer, 0, (int)ms.Length);
                //file.Write(bytes, 0, bytes.Length);
                //file.Close();
                //ms.Close();
                using (FileStream fs = File.OpenWrite(@"C:\bd_sites\ttgme\wwwroot\Evidence\{" + ed.LearnerID + @"}\" + ed.EvidenceFileName))
                {
                    ms.WriteTo(fs);
                    fs.Close();
                    ms.Close();
                }
