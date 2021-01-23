    private void btnCalculate_Click(object sender, EventArgs e)
    {
        var total = 0;
        var textboxes = StackPanelParent.Children.OfType<TextBox>();
        foreach (var textbox in textboxes)
        {
             var input = 0;
             int.TryParse(textbox.Text, out input);
             total += input;
        }
        MessageBox.Show(total.ToString());
    }
    
