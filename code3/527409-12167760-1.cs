    //this class contains controls on the form.
    Class MyApp
    {
        private void btnProcessImages_Click(object sender, EventArgs e)
        {
          try
          {
              Calculate.DevideNumbers(2, 0);
          }
          catch (Exception e)
          {
               DoStuff();
               Return();
          }
        }
    }
