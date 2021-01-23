     if (cbx1.CheckedItems.Count>0)
                {
                   string strcbx = string.Empty;
                    foreach (var item in cbx1.CheckedItems)
                    {
                        strcbx += "'" + item.value + "'" +",";
                    }
                    string listvalue = strcbx.TrimEnd(',');
                }
