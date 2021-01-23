      while ((dbline = dbsr.ReadLine()) != null)
      {
         // Reset
         nsr.BaseStream.Position = 0;
         nsr.DiscardBufferedData(); 
         
         while ((newline = nsr.ReadLine()) != null)
         {
           .....
         }
         nsr.Close(); // remove that
