    public void appendtofile(string text)
    {
    
    
       using (StreamWriter sw = File.AppendText(path)) 
            {
                sw.WriteLine(text);
              
            }
    
    }
