     Dictionary<string, int> obj = new Dictionary<string, int>();
                foreach (Control cn in pnl1.Controls)
                {
                    if (cn.GetType() == typeof(TextBox))
                    {
                        string[] spValue = ((TextBox)cn).Text.Split(' ');
                        if (obj.ContainsKey(spValue[0]))
                        {
                            obj[spValue[0]] = obj[spValue[0]] + Convert.ToInt32(spValue[1]);
                        }
                        else
                        {
                            obj.Add(spValue[0], Convert.ToInt32(spValue[1]));
                        }
                    }
                }
