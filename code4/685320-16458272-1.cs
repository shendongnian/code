		String[] file1Lines = File.ReadAllLines("Text.txt");
        String[] file2Lines = File.ReadAllLines("Text2.txt");
        for (int i = 0; i < Math.Max(file1Lines.Length, file2Lines.Length); i++)
        {
            if (i > file1Lines.Length)
                /* missing from file 1 */
                Console.WriteLine("Missing from File 1");
            else if (i > file2Lines.Length)
                /* missing from file 2); */
               Console.WriteLine("Missing from File 1") ;
            else {
			    DateTime file1Date = DateTime.Now;
				DateTime file2Date = DateTime.Now;
                                // try parse a line from first file
				if(DateTime.TryParse(file1Lines[i], out file1Date)) {
                                      // try parse a line from second file
					if( DateTime.TryParse(file2Lines[i], out file2Date)) {
						if (file1Date.Date == file2Date.Date) {
							/* lines are equal */
							Console.WriteLine("Dates are equal") ;
						} else {
							/* lines are different */
							Console.WriteLine("Dates are different");
						}
					} else {
						Console.WriteLine("Line in file 2 is not a date") ;
					}					
				} else {
					Console.WriteLine("Line in file 1 is not a date") ;
				}
			}
        }
