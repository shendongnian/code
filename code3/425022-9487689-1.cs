      while ((dbline = dbsr.ReadLine()) != null)
      {
         // Reset
         nsr.Position = 0;
         nsr.DiscardBufferedData(); 
         
         while ((newline = nsr.ReadLine()) != null)
         {
           .....
         }
         nsr.Close(); // remove that
