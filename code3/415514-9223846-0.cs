            // some function
            GroupBox g = createGBox();
            this.Controls.Add(g);
            g.Controls.Add(radioButton1);
            g.Controls.Add(radioButton2);
        }
        public GroupBox createGBox()
        {
            GroupBox gBox = new GroupBox();
            gBox.Location = new System.Drawing.Point(72, 105);
            gBox.Name = "BOX";
            gBox.Size = new System.Drawing.Size(200, 100);
            gBox.Text = "This is a group box";
            return gBox;
        }
