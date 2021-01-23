    if (result == DialogResult.OK)
    {
        foreach(string filename = openFileDialog.SafeFileName)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BufferedStream bs = new BufferedStream(fs);
        
            StreamReader sr = new StreamReader(fs);
            String s;
    
                while ((s = sr.ReadLine()) != null)
                {
                    if(s.Contains("Specified string"))
                    {
                        MessageBox.Show(filename + " Contains the Specified string");
                        break;
                    }
                }
    
            fs.Close();
            sr.Close();
        }
    }
