            FileWriter(txtDic.Text, txtWord.Text, true);
            txtWord.Clear();
            MessageBox.Show("Success...");
        }
        public static void FileWriter(string filePath, string text, bool fileExists)
        {
            if (!fileExists)
            {
                FileStream aFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(aFile);
                sw.WriteLine(text);
                sw.Close();
                aFile.Close();
            }
            else
            {
                FileStream aFile = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(aFile);
                sw.WriteLine(text+"/3");
                sw.Close();
                aFile.Close();
                //System.IO.File.WriteAllText(filePath, text);
            }
        }
