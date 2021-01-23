     void listBox_SelectedIndexChanged(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (decimal) Keys.Enter)
            {
                textBox2.Text = ((ListBox)sender).SelectedItem.ToString();
                listBox.Hide();                
            }
        }
