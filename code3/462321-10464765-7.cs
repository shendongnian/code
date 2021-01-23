            public string GetGazetteer(DataTable dtInput)
            {
                string result = null;
                List<Container> containers = new List<Container>();
                StringBuilder sb = new StringBuilder();
                DataTable dt = new DataTable();
                foreach (DataRow row in dtInput.Rows)
                {
                    Container container;
                    container = new Container() { Id = int.Parse(row[0].ToString()), Value = row[1].ToString() };
                    containers.Add(container);
                    if (row[1] != row[3])
                    {
                        container = new Container() { Id = int.Parse(row[0].ToString()), Value = row[3].ToString() };
                        containers.Add(container);
                    }
                }
    
                containers = containers.OrderBy(c => c.Value).ThenBy(c => c.Id).ToList();
    
                if (containers.Count > 0)
                {
                    string initialVal = containers[0].Value;                    
                    for (int i = 1; i < containers.Count; i++)
                    {
                        if (containers[i].Value == initialVal)
                        {
                            sb.Append(containers[i].Id + " is similar to " + containers[i - 1].Id + "</br>");
                        }
                        else
                        {
                            sb.Append(containers[i].Value + "</br>");
                        }
    
                        initialVal = containers[i].Value;
                    }
    
                    result = sb.ToString();
                }
    
                return result;
            }
