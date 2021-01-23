    List<string> slist = new List<string>();
            protected void Page_Load(object sender, EventArgs e)
            {
                string s1 = "first";
                string s2 = "second";
                string s3 = "third";
    
                slist.Add("first");
                slist.Add("second");
                LinkButton b;
    
                
                foreach (string s in slist)
                {
                    b = new LinkButton();
                    b.Text = s;
                    b.Click += (sender1, e1) => { b_Click(sender, e, s1, s2, s3); };
                    
                    this.Form.Controls.Add(b);
                    this.Form.Controls.Add(new LiteralControl("<br/>"));
                }
            }
    
            void b_Click(object sender, EventArgs e, string s1, string s2, string s3)
            {
                UpdateList(s1, s2, s3);
            }
    
            public void UpdateList(string ID, string column, string value)
            {
                // ... enter code here
    
            }
        }
