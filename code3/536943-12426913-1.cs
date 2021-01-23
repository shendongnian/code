    private void OnHandlingSomeEvent(object sender, EventArgs e)
    {
      DialogResult result = folderBrowserDialog1.ShowDialog();
      if(result == DialogResult.OK)
      {
          String folderPath = folderBrowserDialog1.SelectedPath;
          if (UserHasAccess(folderPath)) 
          {
            // yay! you'd obviously do something for the else part here too...
          }
      }
    }
    private bool UserHasAccess(String folderPath)
    {
      try
      {
        // Attempt to get a list of security permissions from the folder. 
        // This will raise an exception if the path is read only or do not have access to view the permissions. 
        System.Security.AccessControl.DirectorySecurity ds =
          System.IO.Directory.GetAccessControl(folderPath);
        return true;
      }
      catch (UnauthorizedAccessException)
      {
        return false;
      }
    }
