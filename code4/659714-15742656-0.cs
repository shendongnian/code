	string[] lines = File.ReadAllLines(@"C:\temp\1.txt");
	
	int[][] numbers = lines.Select(line => line.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries )
										       .Select(int.Parse)
                                               .ToArray())
						   .ToArray();
	
	Console.WriteLine(string.Join(Environment.NewLine, numbers.Select(n => string.Join(" ", n))));
