      private bool doesProcessing { get; set; }
      private void listBox1_SelectedIndexChanging( ... )
      {
         // signal the beginning of processing
         if ( doesProcessing ) 
            return;
         else
            doesProcessing = true; 
         try
         {
            // your logic goes here
         }
         finally
         {
            // signal the end of processing
            doesProcessing = false;
         }
      }
