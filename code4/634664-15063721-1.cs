    var lines = File.ReadAllLines(fileName);    
    var sentences = new List<Sentence>(lines.Count());
    
    foreach (var line in lines)
    {
    	var lineArray = line.Split(':');
    	sentences.Add(new Sentence { sentenceDesignator = lineArray[0], Text = lineArray[1]});
    }
    
    foreach (var sentence in sentences)
    {
    	if (sentence.Text.Contains(searchTerm))
    	{
    		Console.WriteLine(sentence.sentenceDesignator);
    		//Console.WriteLine(sentence.Text);
    	}
    }
