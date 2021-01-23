            ArrayList al = new ArrayList();
            for (int i = 0; i < ListBox1.Items.Count; i++)
            {
                if (ListBox1.Items[i].Selected == true)
                {
                    al.Add(ListBox1.Items[i].Value);
                }
            }
            Session["selectedValues"] = al;
