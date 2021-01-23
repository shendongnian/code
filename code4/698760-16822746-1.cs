                ListItem temp = new ListItem(i + "");
                ddl_EndMin.Items.Add(temp);
                temp = new ListItem(i + "");
                ddl_StartMin.Items.Add(temp);
                if (i < 24)
                {
                    temp = new ListItem(i + "");
                    ddl_EndHour.Items.Add(temp);
                    temp = new ListItem(i + "");
                    ddl_StartHour.Items.Add(temp);
                }
