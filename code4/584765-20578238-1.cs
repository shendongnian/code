                    using (StreamReader sr = new StreamReader("Example.txt"))
                    {
                        string readLine = "text"; //this text has to have at least one character for the program to work
                        int line = 0; //this is to keep track of the line number, it is not necessary
                        while (readLine != "") //make sure the program doesn't keep checking for the text after it has read the entire file.
                        {
                            readLine = sr.ReadLine();
                            line ++; //add one two the line number each time it searches, this searching program searches line by line so I add one just after it searches each time
                            if (readLine.Contains("text"))
                            {
                                //do stuff with your string
                                Console.WriteLine(line + ": readLine"); //you don't have to write it to the screen. You can do absolutely anything with this string now, I wrote the line number to the screen just for fun.
                            }
                        }
                            sr.Close(); //once the search is complete, this closes the streamreader so it can be used again without issues
                    }
