    StreamReader sr1;
    public void showSelectedFile() 
    { 
         sr1 = new StreamReader(File.OpenRead(ReturnTxt))
         ReturnContenctRD = sr1.ReadToEnd();
    }
    public void DisposeSR1() 
    { 
        
    }
