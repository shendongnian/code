    textBox.MouseClick += new MouseEventHandler(textBox_MouseClick);
       
     private void textBox_MouseClick(object sender, MouseEventArgs e)
     {
          if (e.Button == System.Windows.Forms.MouseButtons.Left)
          {
               TextBox textBox = sender as TextBox;
               textBox.Text = string.Empty;
               textBox.Forground = Brushes.Black;
          }
     }
