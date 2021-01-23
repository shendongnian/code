        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        
            /*LinkButton lb = new LinkButton();
            lb.ID = "lbAddFilter";
            pnlFilter.Controls.Add(lb);
            lb.Text = "Add Filter";
            lb.Click += new EventHandler(lbAddFilter_Click);*/
        
            // regenerate dynamically created controls
            foreach ( var employee in employeeList)
            {
                Label myLabel = new Label();
                // Set the label's Text and ID properties.
                myLabel.Text = "Label" + employee.Name.ToString();
                myLabel.ID = "Label" + employee.ID.ToString();
                
                CheckBox chkbx = new CheckBox();
                chkbx.ID = "CheckBox" + employee.ID.ToString();
                chkbx.Text =  "Label" + employee.Name.ToString();
                MyPanel.Controls.Add(myLabel);
                 MyPanel.Controls.Add(chkbx); 
            }
        }
