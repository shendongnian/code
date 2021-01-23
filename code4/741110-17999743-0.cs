    int index1 = comboBox1.SelectedIndex;
    int index2 = comboBox2.SelectedIndex;
    arr[index1, index2] = String.Format("{0:N2}", double.Parse(textBox2.Text));
    arr[index2, index1] = String.Format("{0:N2}", 1 / double.Parse(textBox2.Text)));
    MessageBox.Show("Your Current Rate Have Been Updated"); 
