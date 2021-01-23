    if (!IsPostBack)
            {
                ListItem lstItem = new ListItem("vikas", "0", true);
                lstItem.Attributes.Add("love", "sure");
                chklstbox.Items.Add(lstItem);
                chkBox.Items.Add(lstItem);
                lstItem = new ListItem("kratika", "1", true);
                lstItem.Attributes.Add("love", "not sure");
                chklstbox.Items.Add(lstItem);
                chkBox.Items.Add(lstItem);
            }
