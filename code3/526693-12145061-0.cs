        System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Open);
        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
        
        byte[] buffer = new byte[1024];
        int read = br.Read(buffer, 0, (int)fs.Length);
        br.Close();
        fs.Close(); 
