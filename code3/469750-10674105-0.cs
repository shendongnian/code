    StreamWriter sw = new StreamWriter(@"C:\z\foobar.txt");
    
    foreach(string myObject in myObjects)
    {
        try
        {
          sw.WriteLine(myObject);
        }
        catch (Exception ex)
        {
          // process exception here
          continue;
        }
    }
    
    sw.Flush();
    sw.Close();
