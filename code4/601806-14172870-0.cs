     private void ClickedButton(object sender, EventArgs e)
            {
                Button s = (Button)sender;
                int x = int.Parse(s.Name.Split()[1]);
                int y = int.Parse(s.Name.Split()[3]);
    
                MessageBox.Show("you have clicked button: " + x +" "+ y);
            }
