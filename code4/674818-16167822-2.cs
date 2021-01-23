        private void TxtAge_Leave(object sender, EventArgs e)
        {
            string myString = (sender as TextBox).Text;
            int i = Convert.ToInt16(myString);
            if (i > 150)
            {
                    MessageBox.Show("Invalid Age");
                    TxtAge.Clear();
                (sender as TextBox).Focus();
            }
            
        }
