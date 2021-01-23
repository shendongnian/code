         numbers info = new numbers();
         private void Btn_Click(object sender, EventArgs e)
        { 
          info.numProperty = Convert.ToInt32(numberBOX.Text);
          if (info.isHigh())
          {
            Messagebox.Show("High");
          }
          else
          {
            Messagebox.Show("Low");
          }
        }
