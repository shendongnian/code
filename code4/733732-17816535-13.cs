	private UpdateLabels(string fbStatus)
	{
		var words = GetWords(fbStatus);		
		var info = Process(words);
		label_totalwordcount = info.Item1.ToString();
		label_totaluniquewords.Text = info.Item2.ToString();
		label_lexicaldensity = (info.Item3 * 100).ToString() + "%";
	}
	private Tuple<int, int, double> Process(string[] words)
	{
		int wordCount = Count(words);
		int uniqueWordCount = UniqueWordCount(words);
		double lexicalDensity = ((double)uniqueWordCount / (double)wordCount);
		return new Tuple<int, int, double>(wordCount, uniqueWordCount, lexicalDensity);
	}
