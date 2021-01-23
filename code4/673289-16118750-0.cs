    private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] files = System.IO.Directory.GetFiles(@"C:\test\"); //S:\CPS Papers  test C:\test\
    
            foreach (string file in files)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                //if (fi.LastAccessTime < DateTime.Now.AddMonths(-3))
                if (fi.LastWriteTime < DateTime.Now.AddMonths(-6))
                {
                    fi.Delete();
                    using (StreamWriter writer = File.AppendText("C:\\test\\log\\logfile.txt"))
                    {
                        writer.Write("File: " + file + " deleted at : "+DateTime.Now);
                        writer.WriteLine("----------------------------------------------------");
                        writer.Flush();
                        writer.Close();
    
                    }
                }
    
            }
        }
