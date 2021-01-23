		Dictionary<string,int> dict=new Dictionary<string,int>();
		
		//Split accepts 1 character ,assume each line containes key value pair seperated with spaces and not containing whitespaces
		input=input.Replace("\r\n","\n");
		string[] lines=input.Split('\n');
		//break to categories and find largest number at each 
		foreach(line in lines)
		{
			string parts[]=line.Split(' ');
			string key=parts[0].Trim();
			int value=Convert.ToInt32(parts[1].Trim());
			
			if (dict.ContainsKey(key))
			{
				dict.Add(key, value);
			}
			else
			{
				if (dict[key]<value)
				{
						dict[key]=value;
				}
			}
			
		}
		//do somethig with dict 
