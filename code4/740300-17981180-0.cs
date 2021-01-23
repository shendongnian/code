    holdTypeDDL.Items.Add(new ListItem(string.Empty, false.ToString() + "0"));
    holdTypeDDL.Items.Add(new ListItem(HoldTypeType.Now.Description(), false.ToString() + "1"));
    holdTypeDDL.Items.Add(new ListItem(HoldTypeType.AAHoldType.Description(), true.ToString() + "2"));
    holdTypeDDL.Items.Add(new ListItem(HoldTypeType.AAAHoldType.Description(), true.ToString() + "3"));
    holdTypeDDL.Items.Add(new ListItem(HoldTypeType.AAAAHoldType.Description(), false.ToString() + "4"));
