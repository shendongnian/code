                foreach (string item in ConfigurationManager.AppSettings["Budget"].Split(','))
                {
                    items = item.ToLower() == "any"
                                ? new ListItem(item, "0")
                                : item.Contains("+")
                                      ? new ListItem(String.Format("{0:0,0}+", Convert.ToInt32(item.Replace("+", ""))),
                                                     "999999999")
                                      : new ListItem(String.Format("{0:0,0}", Convert.ToInt32(item)), item);
                    ddlMin.Items.Add(items);
                    ddlMax.Items.Add(items);
                }
