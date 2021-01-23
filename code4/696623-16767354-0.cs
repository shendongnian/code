           try
            {
                _keyboardListener = processTmp;
                _keyboardListener.Start();
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.message);
             
               // OR
              //You can write to any text file using StreamWriter
            }
