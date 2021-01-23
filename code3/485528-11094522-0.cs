    for (int i = 0; i < searcher.MaxDoc(); i++)
            {
                string searchExplanation = searcher.Explain(k, i).ToString();
                int strtIdx = searchExplanation.IndexOf("field=");
                string[] fieldName;
                if (strtIdx != -1)
                {
                    fieldName = searchExplanation.Substring(strtIdx).Split(',');
                    for (int j = 0; j < fieldName.GetLength(0) - 1; j++)
                    {
                        if (fieldNames.IndexOf(fieldName[j].Substring(6)) == -1)
                        {
                            fieldNames.Add(fieldName[j].Substring(6));
                        }
                    }
                }
            }
