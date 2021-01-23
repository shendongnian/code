    richTextBox1.Lines =File.ReadAllLines("D:\\mun.txt")
    Regex regex = new Regex("\\w+");
    var frequencyList = regex.Matches(richTextBox1.Text)
    	.Cast<Match>()
    	.Select(c => c.Value.ToLowerInvariant())
    	.GroupBy(c => c)
    	.Select(g => new { Word = g.Key, Count = g.Count() })
    	.OrderByDescending(g => g.Count)
    	.ThenBy(g => g.Word);
    Dictionary<string, int> dict = frequencyList.ToDictionary(d => d.Word, d => d.Count);
    foreach (var item in frequencyList)
    {
    	label1.Text =label1.Text+item.Word+"\n";
    	label2.Text = label2.Text+item.Count.ToString()+"\n";
    }
