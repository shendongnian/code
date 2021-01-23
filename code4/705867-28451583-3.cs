    private static void NumericCheck(object sender, KeyPressEventArgs e)
    {
        DataGridViewTextBoxEditingControl s = sender as DataGridViewTextBoxEditingControl;
        if (s != null && (e.KeyChar == '.' || e.KeyChar == ','))
        {
            e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            e.Handled = s.Text.Contains(e.KeyChar);
        }
        else
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
    }
