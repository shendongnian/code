    FileStream fs = new FileStream(myfilepath, FileMode.Create, FileAccess.Write);            
    byte[] bt = System.Text.Encoding.ASCII.GetBytes(mystring);
    fs.Write(bt, 0, bt.Length);
    fs.Close();
   
    
