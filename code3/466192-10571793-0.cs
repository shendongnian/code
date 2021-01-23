    ...
    DropDownList DropDownList2 = 
       (DropDownList)Wizard1.WizardSteps[1].FindControl("DropDownList1");
    DropDownList2.DataBind();
    DropDownList2.Items.FindByValue(
        DataSetLoad.Tables[1].Rows[0]["a"].ToString()).Selected = true;
    ...
}
