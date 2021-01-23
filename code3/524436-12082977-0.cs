    catch (SystemException ex)
    {
          if(ex.Message == "Path is not of legal form.")
          {
              throw new Exception("Hey you idiot, go into the application settings and specify a valid path", ex);
          }
          else
          {
              MessageBox.Show(ex.Message,"Error");
          }
    }
