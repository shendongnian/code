     List<string> list = new List<string>();
                list.Add("1");
                list.Add("1.1");
                list.Add("1,A");
                list.Add("2,/,1");
    
    
                foreach (var item in list)
    	        {
                    if (!Regex.IsMatch(item, @"^([0-9](,[0-9])*)$"))
                    {
                        Console.WriteLine("no match :" + item);
    
                    }
    		    }
