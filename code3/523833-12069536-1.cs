    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        string keyword = textBox1.Text;
        if (string.IsNullOrEmpty(keyword.Trim()))
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(_originalList.ToArray());
        }
        else
        {
            Regex regex = new Regex(GetRegexPatternFromKeyword(keyword));
            List<string> selection =
                _originalList.Where(s => regex.IsMatch(s)).ToList();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(selection.ToArray());
        }
    }
    private static string GetRegexPatternFromKeyword(string keyword)
    {
        string[] words =
            keyword.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(word => "(?=.*" + word.Replace(")", @"\)") + ")").ToArray();
        return string.Join("", words);
    }
