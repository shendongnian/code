        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox[] boxes = new CheckBox[7];
            boxes[0] = this.CheckBoxID;
            boxes[1] = this.CheckBoxID;
            boxes[2] = this.CheckBoxID;
            boxes[3] = this.CheckBoxID;
            boxes[4] = this.CheckBoxID;
            boxes[5] = this.CheckBoxID;
            boxes[6] = this.CheckBoxID; //you can add checkboxes as you want
            CheckBox chkBox = (CheckBox)sender;
            string chkID = chkBox.ID;
            bool allChecked = true;
            if (chkBox.Checked == false)
                allChecked = false;
            foreach (CheckBox chkBoxes in boxes)
            {
                if (chkBox.Checked == true)
                {
                    if (chkBoxes.Checked == false)
                        allChecked = false;
                }
            }
            this.CheckBoxIDALL.Checked = allChecked; //Here place the main CheckBox
        }
