    private void GeneralTextBoxMouseEnter(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            MessageBox.Show(Grid.GetColumn(tb));
        }
