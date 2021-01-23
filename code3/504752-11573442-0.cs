    void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                {
                  if(work not saved)//Check your condition
                   {
                     MessageBox.Show("Unsave Work");
                     e.Cancel = true;
                    }
                }
        }
