            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var result = new List<string>();
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    result.Add(array_questions[i, j]);
                }
               Response.Write(string.Join(", ", result) + Environment.NewLine);
            }
