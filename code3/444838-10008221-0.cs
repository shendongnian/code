    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    foreach (var item in list1.OfType<string[]>().SelectMany(i => i))
    {
        sb.Append(item);
    }
 
    textBox1.Text = sb.ToString();
