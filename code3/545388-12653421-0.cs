    FileData fd = new FileData(new BatchData());
    void createOutputBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        using (StreamReader sr = File.OpenText("D:/data.txt"))
        {
           String input;    
           while ((input = sr.ReadLine()) != null)
           {
                string[] stringArray = input.Split(',');
                PropertyInfo[] props = typeof (FileData).GetProperties();
                for (int i = 0; i < stringArray.Count() - 1; i++)
                {
                      props[i].SetValue(fd, stringArray[i]);
                }
           }
       }
    }
