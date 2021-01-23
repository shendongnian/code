       //Get the number of the button control (last digit of the name)
       string strNum = bt.Name.Substring(bt.Name.Lenght -2);
       foreach(Control ctrl in myPanel.Controls)
        {
            if(ctrl is ComboBox) {
               if(ctrl.Name.EndsWith(strNum)) {
                 //Do Something with your found ComboBox ...
                }
             }
        }
