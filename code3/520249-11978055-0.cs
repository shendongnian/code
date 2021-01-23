        private List<KeyValuePair<string, string>> SplitBoxLine(String input)
        {
            //SAMPLE input:
            //30: "NY", 41: "JOHN S.", 36: "HAMPTON", 42: "123 Road Street, NY", 68: "Y", 40: 12345
            List<KeyValuePair<string, string>> boxes = new List<KeyValuePair<string, string>>();
            int quoteCount = 0;
            String buffer = "";
            String boxNum = "";
            String boxValue = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    //if the input character at the end ISN'T a quote or comma, add it to the buffer
                    //supports the case where the last item is 40: 12345
                    if (input[i] != ',' && input[i] != '\"')
                    {
                        buffer += input[i];
                    }
                    boxValue = String.Copy(buffer.Trim());
                    //once we have the value, we can create the pair
                    KeyValuePair<string, string> pair = new KeyValuePair<string, string>(boxNum, boxValue);
                    boxes.Add(pair);
                    Console.WriteLine("BOX VALUE [LAST ITEM]: " + boxValue);
                }
                if (input[i] == ':')
                {
                    boxNum = String.Copy(buffer.Trim());
                    buffer = "";
                    Console.WriteLine("BOX NUM: " + boxNum);
                }
                else if (input[i] == '\"')
                {
                    quoteCount++;
                }
                else if (input[i] == ',')
                {
                    if (quoteCount % 2 == 0) //comma occurs outside of quotes
                    {
                        boxValue = String.Copy(buffer.Trim());
                        buffer = "";
                        //once we have the value, we can create the pair
                        KeyValuePair<string, string> pair = new KeyValuePair<string, string>(boxNum, boxValue);
                        boxes.Add(pair);
                        Console.WriteLine("BOX VALUE: " + boxValue);
                    }
                    else //the comma occurs in some quotes
                    {
                        buffer += input[i]; //add the comma, it's just part of the boxValue
                    }
                }
                //nothing special about this chacter, add it to the buffer and continue
                else
                {
                    buffer += input[i];
                }
            }
            return boxes;
        }
