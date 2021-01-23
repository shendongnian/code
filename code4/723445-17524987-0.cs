                for (int i = 3; i < lines.Count; i++)
                {
                    resultsTreeView.Items.Add(lines[i].ToString().Substring(67,17));
                    resultsTreeView.Items.Add(new CheckBox()); 
                    // resultsTreeView.Items.Add(BuildCheckBox())
                }
