        List<string> lines_list = new List<string>();
        int file_l = 0
    
        StreamReader sr_temp = new StreamReader(_path);
        string line;
    
        while ((line = sr_temp.ReadLine()) != null)
        {
             lines_list.Add(line);
             file_l++;
        }
    
        sr_temp.Close();
        StreamWriter sw = new StreamWriter(_path);
        for (int i = 0; i < file_l; i++)
        {
              sw.WriteLine(lines_list[i]);
        }
        
        //here you add some data
        sw.Close();
