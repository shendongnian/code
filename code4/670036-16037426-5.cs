    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var lines = new List<string>();
        foreach (TextBox tb in WindowHelper.FindVisualChildren<TextBox>(this))
            lines.Add(string.Format("{0},{1}", tb.Name, tb.Text));
        foreach (ComboBox cb in WindowHelper.FindVisualChildren<ComboBox>(this))
            lines.Add(string.Format("{0},{1}", cb.Name, cb.Text));
        System.IO.File.WriteAllLines(@"data.csv", lines);
    }
