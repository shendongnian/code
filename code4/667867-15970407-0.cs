      private void Rom1_Click_1(object sender, EventArgs e)
        {                  
           if (Rom1.BackColor == Color.Red)
            {
                Rom1.BackColor = Color.Green;
                ledigeRom++;
            }    
            else
            {
                Rom1.BackColor = Color.Red;
                ledigeRom--;
            }   
         //include this
          this.tabPage1.Text = "1.Etasje " + ledigeRom;          
        }
