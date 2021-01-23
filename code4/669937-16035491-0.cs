            CheckBox check = new CheckBox();
            check.Checked = true;
            check.AccessibleName = checkName;
            check.Location = new System.Drawing.Point(340, 40);
            check.CheckedChanged +=new EventHandler(check_CheckedChanged);
            this.Controls.Add(check);
