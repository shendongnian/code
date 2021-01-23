    ...catch (SystemException ex)
    {
       if(ex is ArgumentException)
          {
              MessageBox.Show("Hey you idiot, go into the application settings and specify a valid path","Error");
          }
          else
          {
              MessageBox.Show(ex.Message,"Error");
          }
    }
