            bool firstRow = true;
            List<string> columnNames = new List<string>();
            List<Tuple<string, string, string>> results = new List<Tuple<string, string, string>>();
            while (parser.Read())
            {
                if (firstRow)
                {
                    for (int i = 0; i < parser.ColumnCount; i++)
                    {
                        if (parser.GetColumnName(i).Contains("FY"))
                        {
                            columnNames.Add(parser.GetColumnName(i));
                            Console.Log("Column found: {0}", parser.GetColumnName(i));
                        }
                    }
                    firstRow = false;
                }
                foreach (var col in columnNames)
                {
                    double actualCost = 0;
                    bool hasValueParsed = Double.TryParse(parser[col], out actualCost);
                    csvData.Add(new ProjectCost
                    {
                        ProjectItem = parser["ProjectItem"],
                        ActualCosts = actualCost,
                        ColumnName = col
                    });
                }
            }
