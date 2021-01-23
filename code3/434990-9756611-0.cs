     try
     {
          string foo = ApplicationDeployment.CurrentDeployment.DataDirectory;
     }
     catch (Exception e)
     {
          MessageBox.Show("Exception: " + e.Message + "\n" + e.StackTrace);
     }
