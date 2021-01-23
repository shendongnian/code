       listbox1.BeginUpdate();
       for (int i = 0; i < kvp.Value.Count(); i++)
                    {
                        sb = "Url: " + kvp.Key + " --- " + "Local KeyWord: " + kvp.Value[i] + Environment.NewLine;
                        listbox1.Add(sb.ToString());
                    }
       listbox1.EndUpdate();
