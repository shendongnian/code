	private UpdateLabels(string fbStatus)
	{
		var words = GetWords(fbStatus);		
		var info = Process(words);
		label_totalwordcount = info.WordCount.ToString();
		label_totaluniquewords.Text = info.UniqueWordCount.ToString();
		label_lexicaldensity = (info.LexicalDensity * 100).ToString() + "%";
	}
	private LexicalInfo Process(string[] words)
	{
		int wordCount = Count(words);
		int uniqueWordCount = UniqueWordCount(words);
		double lexicalDensity = ((double)uniqueWordCount / (double)wordCount);
		return new LexicalInfo()
                {
                    WordCount = wordCount,
                    UniqueWordCount = uniqueWordCount,
                    LexicalDensity = lexicalDensity
                };
	}
