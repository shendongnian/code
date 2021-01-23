    private void button1_Click(object sender, EventArgs e)
    {
          var rc = new Random();
          do
          {
            storeRI = rc.Next(1, 9);
            if (storeRI == 1)
            {
                if (button1.Text == "")
                {
                    button1.Text = "X";
                }
            }
            else if (storeRI == 2)
            {
                if (button1.Text == "")
                {
                    button1.Text = "X";
                }
            }
          } while (button1.Text == "");
     }
