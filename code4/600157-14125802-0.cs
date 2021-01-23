		string Combine (IEnumerable<string> list)
		{
			bool start = true;
			var last = string.Empty;
			String str = string.Empty;
			
			foreach(var item in list)
			{
				if ( !start)
				{
					str = str + " , " + item; 
					last = item;
				
				}
				else
				{
					str = item;
					start = false;
				} 
			
			}
			
			if (!string.IsNullOrWhiteSpace(last))
			{
				str = str.Replace( " , " + last, " and " + last);
			}
		
			return str;
		}
