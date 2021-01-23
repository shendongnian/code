    IEnumerable<String> lines = File.ReadLines(path);
    textBoxAmount.Text = lines.ElementAtOrDefault(0);
    textBoxCategories.Text = lines.ElementAtOrDefault(1);
    textBoxValue.Text = lines.ElementAtOrDefault(2);
    textBoxValue.Text = lines.ElementAtOrDefault(3);
