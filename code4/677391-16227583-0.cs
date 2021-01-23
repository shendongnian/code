        FileStream fsr = new FileStream("fileone.txt", FileMode.Open, FileAccess.Read);     
        StreamReader Sr = new StreamReader(fsr);      
        string line = string.Empty;
        var ctr = 0;
        while(ctr < 3){
          line = Sr.ReadLine();
          ctr++;
        }
        Console.WriteLine(line);
        Sr.Close();
        fsr.Close();
    }
