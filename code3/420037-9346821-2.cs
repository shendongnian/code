    protected void btn_Click(object sender, EventArgs e)
            {
                Dictionary<string, int> obj = new Dictionary<string, int>();
                foreach (Control cn in pnl1.Controls)
                {
                    if (cn.GetType() == typeof(TextBox))
                    {
                        if (((TextBox)cn).Text.Trim() != "")
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
                }
                foreach (string k in obj.Keys)
                {
                    TextBox tx = new TextBox();
                    tx.Text = k + " " + obj[k].ToString();
                    pnl1.Controls.Add(tx);
                }
            }
