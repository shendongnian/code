    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
    	Dictionary<int, int> dict = GetDictionaryWithData();
    	try {
    		DoProcessing(dict);
    	} catch (AggregateException ex) {
    		RichTextBox1.Text = ex.ToString;
    	}
    }
    
    private Dictionary<int, int> GetDictionaryWithData()
    {
    	Dictionary<int, int> dict = new Dictionary<int, int>();
    	{
    		dict.Add(5, 5);
    		dict.Add(4, 0);
    		dict.Add(3, 0);
    		dict.Add(2, 2);
    		dict.Add(1, 0);
    	}
    	return dict;
    }
    
    private void DoProcessing(Dictionary<int, int> dict)
    {
    	List<Exception> exceptions = new List<Exception>();
    	for (int i = 0; i <= dict.Count - 1; i++) {
    		int key = dict.Keys(i);
    		int value = dict.Values(i);
    		try {
    			int result = key / value;
    		} catch (Exception ex) {
    			exceptions.Add(ex);
    		}
    	}
    	if (exceptions.Count > 0)
    		throw new AggregateException(exceptions);
    }
