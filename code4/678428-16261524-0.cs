        public int childrenCount; //The number of children
        private void button1_Click(object sender, EventArgs e) { //Adds a child
            childrenCount++;
            Panel p = new Panel();
            p.Location = new Point(10, (childrenCount - 1) * 200);
            p.Width = 300;
            p.Height = 200;
            p.BorderStyle = BorderStyle.Fixed3D;
            TextBox tName = new TextBox(); //TextBox for the name
            tName.Location = new Point(200, 20);
            tName.Text = "name";
            MonthCalendar calendar = new MonthCalendar(); //Calendar to choose the birth date
            TextBox bloodGroup = new TextBox(); //TextBox for the blood group
            bloodGroup.Location = new Point(200, 50);
            bloodGroup.Text = "blood group";
            p.Controls.Add(tName);
            p.Controls.Add(calendar);
            p.Controls.Add(bloodGroup);
            this.Controls.Add(p);
        }
        private void button2_Click(object sender, EventArgs e) { //Checks the values
            string message = "";
            foreach(Control c in this.Controls) { //loop throught the elements of the form
                if (c.GetType() == typeof(Panel)) { //check if the control is a Panel
                    //Get the values from the input fields and add it to the message string
                    Panel p = (Panel)c;
                    TextBox tName = (TextBox)(c.Controls[0]);
                    MonthCalendar calendar = (MonthCalendar)(c.Controls[1]);
                    TextBox bloodGroup = (TextBox)(c.Controls[2]);
                    message += tName.Text + ":\n";
                    message += "birth date: " + calendar.SelectionStart.ToShortDateString() + "\n";
                    message += "blood group: " + bloodGroup.Text + "\n\n";
                }
            }
            //show the message string in a MessageBox
            MessageBox.Show(message);
        }
