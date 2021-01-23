     StreamWriter sw;
     try
     {
        sw = new StreamWriter(strFilePath, false);
     }
     catch
     {
        // Never do an empty catch BTW!    
     }
     finally
     {
       if (sw != null)
       {
         sw.Flush();
         sw.Close();
         sw.Dispose();
       }
    }
