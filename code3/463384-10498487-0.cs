    public void ParseFile(){
            String currentLine;
            bool newSection = false;
            //Store the column names and ordinal position here.
            List<String> nameOrdinals = new List<String>();
            nameOrdinals.Add("Name"); //IndexOf == 0
            Dictionary<Int32, List<String>> nameValues = new Dictionary<Int32 ,List<string>>(); //Use this to store each person's details
            Int32 rowNumber = 0;
            using (TextReader reader = File.OpenText("D:\\temp\\test.txt"))
            {
                while ((currentLine = reader.ReadLine()) != null) //This will read the file one row at a time until there are no more rows to read
                {
                    string[] lineSegments = currentLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (lineSegments.Length == 2 && String.Compare(lineSegments[0], "Name", StringComparison.InvariantCultureIgnoreCase) == 0
                        && String.Compare(lineSegments[1], "Details", StringComparison.InvariantCultureIgnoreCase) == 0) //Looking for a Name  Details Line - Start of a new section
                    {
                        rowNumber++;
                        newSection = true;
                        continue;
                    }
                    if (newSection && lineSegments.Length > 1) //We can start adding a new person's details - we know that 
                    {
                        nameValues.Add(rowNumber, new List<String>());
                        nameValues[rowNumber].Insert(nameOrdinals.IndexOf("Name"), lineSegments[0]);
                        //Get the first column:value item
                        ParseColonSeparatedItem(lineSegments[1], nameOrdinals, nameValues, rowNumber);
                        newSection = false;
                        continue;
                    }
                    if (lineSegments.Length > 0 && lineSegments[0] != String.Empty) //Ignore empty lines
                    {
                        ParseColonSeparatedItem(lineSegments[0], nameOrdinals, nameValues, rowNumber);
                    }
                }
            }
            //At this point we should have collected a big list of items. We can then write out the CSV. We can use a StringBuilder for now, although your requirements will
            //be dependent upon how big the source files are.
            
            //Write out the columns
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < nameOrdinals.Count; i++)
            {
                if(i == nameOrdinals.Count - 1)
                {
                    builder.Append(nameOrdinals[i]);
                }
                else
                {
                    builder.AppendFormat("{0},", nameOrdinals[i]);
                }
            }
            builder.Append(Environment.NewLine);
            foreach (int key in nameValues.Keys)
            {
                List<String> values = nameValues[key];
                for (int i = 0; i < values.Count; i++)
                {
                    if (i == values.Count - 1)
                    {
                        builder.Append(values[i]);
                    }
                    else
                    {
                        builder.AppendFormat("{0},", values[i]);
                    }
                }
                builder.Append(Environment.NewLine);
            }
            //At this point you now have a StringBuilder containing the CSV data you can write to a file or similar
        }
        private void ParseColonSeparatedItem(string textToSeparate, List<String> columns, Dictionary<Int32, List<String>> outputStorage, int outputKey)
        {
            if (String.IsNullOrWhiteSpace(textToSeparate)) { return; }
            string[] colVals = textToSeparate.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            List<String> outputValues = outputStorage[outputKey];
            if (!columns.Contains(colVals[0]))
            {
                //Add the column to the list of expected columns. The index of the column determines it's index in the output
                columns.Add(colVals[0]);
                 
            }
            if (outputValues.Count < columns.Count)
            {
                outputValues.Add(colVals[1]);
            }
            else
            {
                outputStorage[outputKey].Insert(columns.IndexOf(colVals[0]), colVals[1]); //We append the value to the list at the place where the column index expects it to be. That way we can miss values in certain sections yet still have the expected output
            }
        }
