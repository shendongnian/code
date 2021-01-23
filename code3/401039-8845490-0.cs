	enum DictKeys
	{
	    nameValue1,
	    nameValue2,
	}
    void Main()
    {
        var myDictionary = new Dictionary<string, string>();
        myDictionary.Add("namevalue1", "value1");
        myDictionary.Add("namevalue2", "value2");
        
        Console.WriteLine(myDictionary["namevalue1"]); // "value1"
        
        var myDict2 = new Dictionary<DictKeys, string>();
        myDict2.Add(DictKeys.nameValue1, "value1");
        myDict2.Add(DictKeys.nameValue2, "value2");
        
        Console.WriteLine(myDict2[DictKeys.nameValue1]); // "value1"
    }
    
