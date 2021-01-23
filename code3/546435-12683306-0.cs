    using (StreamReader myReader = new StreamReader("Values.txt"))
                {
                    string line = "";
                    while (line != null)
                    {
    
                        line = myReader.ReadLine();
                        if (line != null)
                            console.WriteLine(line);
                    }
    
                    //myReader.Close();
                    console.ReadLine();
                };
