         int total = list_failed.Items.Count;
    using (StreamWriter sw= new StreamWriter(folderPath+"\\"+GetFilePath()))
    {
           for (int i = 0; i < list_failed.Items.Count; i++)
            {
                
                sw.WriteLine(list_failed.Items[i]);
            }
                sw.Close();
    }
