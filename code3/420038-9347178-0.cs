            string previousLine = "";
            foreach (var lines in textBox1.Lines) 
            { 
                    string line = lines.TrimEnd(); 
                    if (line.Length > 0 && previousLine != "") 
                    { 
                        int findIndex = line.LastIndexOf(" ") + 1;
                        //check to ensure the item in this line is equal to the item in the previous line 
                        if(line.substring(0, findIndex - 2) == previousLine.substring(0, findIndex - 2))
                        {
                            var qty = (line.Substring(findIndex)); 
                            int lineInt; 
                            try 
                            {
                                lineInt = Convert.ToInt32(qty);  //convert whatever the qty detected was, to int32 
                                {
                                    int previousStringNum = Int32.TryParse(previousLine.Substring(previousLine.LastIndexOf(" ") + 1)
                                    int sumOfLineAndPreviousLine = lineInt + previousStringNum;
                                    //set the line variable equal to its new value which includes the value from the previous line
                                    line = line.substring(0, line.length - 2) + sumOfLineAndPreviousLine.ToString();
                                    //textBox2.Text += line + lineInt+Environment.NewLine.ToString();
                                    //set the previousLine variable equal to line so that the next pass of the foreach loop if that object equals the object in previousLine, it will continue to add them... 
                                    previousLine = line;
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                             //the object in this line is not equal to the object in the previousLine
                             //so append the previousLine to the TextBox2.Text and then
                             //set the previousLine object equal to the current Line so that on the 
                             //next pass of the loop will work correctly
                             textBox2.Text = textBox2.Text + previousLine;
                             previousLine = line;
                         
                        }
                    }  
            } 
