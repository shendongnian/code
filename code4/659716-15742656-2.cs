	string[] lines = File.ReadAllLines(@"C:\temp\1.txt");
	var options = StringSplitOptions.RemoveEmptyEntries;
	int[][] numbers = lines.Select(line => line.Split(new[]{' '}, options)
										       .Select(int.Parse)
                                               .ToArray())
						   .ToArray();
	
	Console.WriteLine(string.Join(Environment.NewLine, 
                                  numbers.Select(n => string.Join(" ", n))));
