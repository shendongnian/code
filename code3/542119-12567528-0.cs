    public static string GetString(string val, int number)
    		{
    			List<string> res = new List<string>();
    			res.Add("");
    
    			int counter = 0, i = 0;
    			while (i < val.Length)
    			{
    				while (res[counter].Length < number && i < val.Length)
    				{
    					res[counter] += val[i];
    					i++;
    				}
    				res.Add("");
    				counter++;
    			}
    
    			return string.Join(",", res.Where(r => !string.IsNullOrEmpty(r)));
    		}
