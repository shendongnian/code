	string str = "105, c#, vb, 345, 53, sql51";
	var separator = ", ";
	int dummy;
	
	var parts = str.Split(new[]{separator}, StringSplitOptions.RemoveEmptyEntries)
				   .Where(s => !int.TryParse(s, out dummy));
				   
	string result = string.Join(separator, parts);
						
	Console.WriteLine(result);
