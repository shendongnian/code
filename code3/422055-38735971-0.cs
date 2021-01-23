        private void ChangeState(object sender,EventArgs e){
            ComboBox stateComboBox= (ComboBox)sender;
            //find the name of target City ComboBox
            string cityComboName = "City"+stateComboBox.Name.Substring(5); // 5 is the Length of 'State'
            ComboBox cityComboBox=null;
            foreach(Control cntrl in panel1.Controls){
                if (cntrl.Name == cityComboName) {
                    cityComboBox= (ComboBox)cntrl;
                    break;
                }
            }
            if (cityComboBox!= null) {
                cityComboBox.Enabled = true;
                // now you have the both cityComboBox and stateComboBox Of the same Row
            }
        }
