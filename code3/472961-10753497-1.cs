    System.Text.Encoding enc = null; 
    System.IO.FileStream file = new System.IO.FileStream(filePath, 
        FileMode.Open, FileAccess.Read, FileShare.Read); 
    if (file.CanSeek) 
    { 
        byte[] bom = new byte[4]; // Get the byte-order mark, if there is one 
        file.Read(bom, 0, 4); 
        if ((bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) || // utf-8 
            (bom[0] == 0xff && bom[1] == 0xfe) || // ucs-2le, ucs-4le, and ucs-16le 
            (bom[0] == 0xfe && bom[1] == 0xff) || // utf-16 and ucs-2 
            (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff)) // ucs-4 
        { 
            enc = System.Text.Encoding.Unicode; 
        } 
        else 
        { 
            enc = System.Text.Encoding.ASCII; 
        } 
      
        // Now reposition the file cursor back to the start of the file 
        file.Seek(0, System.IO.SeekOrigin.Begin); 
    } 
    else 
    { 
        // The file cannot be randomly accessed, so you need to decide what to set the default to 
        // based on the data provided. If you're expecting data from a lot of older applications, 
        // default your encoding to Encoding.ASCII. If you're expecting data from a lot of newer 
        // applications, default your encoding to Encoding.Unicode. Also, since binary files are 
        // single byte-based, so you will want to use Encoding.ASCII, even though you'll probably 
        // never need to use the encoding then since the Encoding classes are really meant to get 
        // strings from the byte array that is the file. 
        enc = System.Text.Encoding.ASCII; 
    }
