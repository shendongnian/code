        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (Int32.TryParse(maskedTextBox1.Text, out num) == true) 
            {
                if (num < 0 || num > 100)
                {
                    MessageBox.Show("Insert number between 0 and 100");
                    e.Cancel = true;
                }
            }
        }
