    if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(MapPath("XMLFile.xml"));
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            HiddenField ctrl = (HiddenField)e.Item.FindControl("HiddenField1");
            if (ctrl.Value == "1")//1 for Textbox
            {
                TextBox txtCtrl = (TextBox)e.Item.FindControl("TextBox1");
                txtCtrl.Visible = true;
            }
            else if (ctrl.Value == "3")//3 for Radio Button
            {
                RadioButton rdbYCtrl = (RadioButton)e.Item.FindControl("RadioButton1");
                RadioButton rdbNCtrl = (RadioButton)e.Item.FindControl("RadioButton2");
                rdbYCtrl.Visible = true;
                rdbNCtrl.Visible = true;
            }
            else if(ctrl.Value == "2")//2 for Chackbox
            {
                 CheckBox chkCtrl = (CheckBox)e.Item.FindControl("CheckBox1");
                 chkCtrl.Visible = true;
            }
       
        }
    }
