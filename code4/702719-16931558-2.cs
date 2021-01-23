            var sdArray= new List<string>();
            for (var i = 0; i < dt.Rows.Count; i++) //Get the length of first Dimension
            {
                for (var j = 0; j < dt.Columns.Count; j++) //Get the length of second Dimension
                {
                    sdArray.Add(array_questions[i, j]);
                }
            }
           ///
            Response.Write(string.Join(", ", sdArray) + Environment.NewLine);
  
