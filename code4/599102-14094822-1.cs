      private static void ErrorOutput(object sender, DataReceivedEventArgs e)
      {
         if (e.Data != null)
         {
            stdout = "Error: " + e.Data;
         }
      }
      private static void ReadOutput(object sender, DataReceivedEventArgs e)
      {
         if (e.Data != null)
         {
            stdout = e.Data;
         }
      }
