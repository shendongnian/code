            public string GetGazetteer(DataTable dtInput)
            {
                string result = null;
                List<Container> containers = new List<Container>();
                List<Container> finalContainers = new List<Container>();
                StringBuilder sb = new StringBuilder();
                DataTable dt = new DataTable();
                foreach (DataRow row in dtInput.Rows)
                {
                    Container container;
                    container = new Container() { Id = int.Parse(row[0].ToString()), Value = row[1].ToString(), Col = 1 };
                    containers.Add(container);
                    if (row[1] != row[3])
                    {
                        container = new Container() { Id = int.Parse(row[0].ToString()), Value = row[3].ToString(), Col = 2 };
                        containers.Add(container);
                    }
                }
    
                containers = containers.OrderBy(c => c.Value).ThenBy(c => c.Id).ToList();
    
                if (containers.Count > 0)
                {
                    string initialVal = containers[0].Value;
                    finalContainers.Add(containers[0]);
                    for (int i = 1; i < containers.Count; i++)
                    {
                        if (containers[i].Value == initialVal)
                        {
                            finalContainers.Remove(containers[i]);
                            finalContainers.Remove(containers[i - 1]);
                            finalContainers.Add(new Container() { Id = containers[i - 1].Id, Value = "*" + containers[i - 1].Id + " is duplicate of " + containers[i].Id + "* " + containers[i - 1].Value });
                            finalContainers.Add(new Container() { Id = containers[i].Id, Value = "*" + containers[i].Id + " is duplicate of " + containers[i - 1].Id + "* " + containers[i].Value });
                        }
                        else
                        {
                            finalContainers.Add(containers[i]);
                        }
    
                        initialVal = containers[i].Value;
                    }
    
                    finalContainers = finalContainers.OrderBy(c => c.Id).ThenBy(c => c.Col).ToList();
    
                    foreach (Container container in finalContainers)
                    {
                        sb.Append(container.Value + "</br>");
                    }
    
                    result = sb.ToString();
                }
    
                return result;
            } 
           
