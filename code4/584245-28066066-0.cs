      DialogResult result;
     private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            string message = "would you like to see mouse up event?";
            string caption = "event trick";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            
            result = MessageBox.Show(message, caption, buttons);
            textBox1.Text = result.ToString();
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                button1_MouseUp(sender, e);
            }
            
        }
