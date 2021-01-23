    public List<LineComparer> _comparer = new List<LineComparer>();
    
    public void ReadFiles()
    {
    	TextReader tr1 = new StreamReader("file1.txt");
    	TextReader tr2 = new StreamReader("file2.txt");
    
    	string line1, line2 = null;
    
    	while ((line1 = tr1.ReadLine()) != null)
    	{
    		_comparer.Add(new LineComparer{ Line1 = line1 });
    	}
    
    	int index = 0;
    
    	while ((line2 = tr2.ReadLine()) != null)
    	{
    		if(index < _comparer.Count)
    			_comparer[index].Line2 = line2;
    		else
    			_comparer.Add(new LineComparer{ Line2 = line2 });
    		index++;
    	}
    	  
    	tr1.Close();
    	tr2.Close();
    
    	_comparer.ForEach(x => { if(x.Line1 != x.Line2) x.Color = new SolidColorBrush(Colors.Red); else x.Color = new SolidColorBrush(Colors.Green); });
    }
