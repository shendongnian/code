                StreamReader myFile = new StreamReader("TextFile1.txt");
                int lineNumber = 0;
                while (!myFile.EndOfStream)
                {
                    // Read the next line.
                    string inputLine = myFile.ReadLine();
                    lineNumber++;
    
                    // Extract fields line.
                    string[] splitInput = inputLine.Split();
    
                    // Make sure the line has the correct number of fields.
                    if (splitInput.Length == 5)
                    {
                        // Parse and validate each field.
    
                        if (!int.TryParse(splitInput[0], out EmpNum))
                        {
                            Console.WriteLine("could not parse int " + splitInput[0] + " on line " + lineNumber);
                            continue;
                        }
    
                        EmpName = (splitInput[1]);
    
                        EmpAdd = (splitInput[2]);
    
                        if(!double.TryParse(splitInput[3], out EmpWage))
                        {
                            Console.WriteLine("could not parse double " + " on line " + lineNumber);
                            continue;
                        }
    
                        EmpHours = double.Parse(splitInput[4]);
    
                        if (!double.TryParse(splitInput[4], out EmpWage))
                        {
                            Console.WriteLine("could not parse double: " + " on line " + lineNumber);
                            continue;
                        }
    
                        // Output
                        Console.WriteLine("test {0},{1},{2}", EmpNum, EmpWage, EmpHours);
                    }
                    else
                    {
                        Console.WriteLine("Expecting 5 items from split opertation but got " + splitInput.Length  + " on line " + lineNumber);
                    }
                }
                myFile.Close();
 
