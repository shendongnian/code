     ArrayList alist = new ArrayList();
            alist.Add("First");
            alist.Add("Second");
            int loopCount=1;
            foreach (String s in alist)
            {
                // add new checkbox with different name for each string in alist
                CheckBox c = new CheckBox();
                c.Name = s;
                c.Text = s;
                c.Parent = this;
                c.Visible = true;
                //position the checkbox
                c.Top = loopCount*c.Height;
                
                this.Controls.Add(c);
                loopCount++;
            }
