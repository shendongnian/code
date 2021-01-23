    class MyApp
    {
        bool erroroccurs = false;
        private void btnProcessImages_Click(object sender, EventArgs e)
        {
              try
              {
                  Calculate.DevideNumbers(2, 0);
              }
              catch(Exception)
              {
                  erroroccurs = true;
              }
        }
    }
