          try
            {
                //connection here
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // will give you the error if no connection and you can get an idea why it crashes
            }
