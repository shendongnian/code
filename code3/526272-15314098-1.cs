     private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
     {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            e.Handled = true;
            SendKeys.Send("{tab}");
        }
     }
