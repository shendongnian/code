       private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (txtNumbers.Text != "")
            {
                if (!int.TryParse(txtNumbers.Text, out result))
                {
                    txtNumbers.Text = "";
                    MessageBox.Show("Invalid Integer");                    
                }
            }
        }
