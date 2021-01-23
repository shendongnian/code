            List<String> columns = new List<string>();
            columnposition = columns.FindIndex (s => string.Equals(s, reader.Name);
            if (columnposition < 0)
            {
                columns.Add ( reader.Name);
                columnposition = columns .Count -1;
                // .. do the other stuff 
            }
