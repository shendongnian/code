    MaterialDB materials = new MaterialDB();
    DropDownList listBoxMaterials = new DropDownList();
    listBoxMaterials.DataSource = materials.GetItems(ModuleId, TabId);
    listBoxMaterials.DataTextField = "MaterialName";
    listBoxMaterials.DataTextValue = "MaterialID";
    listBoxMaterials.DataBind();
    
    string materialString = "";    
    
    foreach (ListItem i in listBoxMaterials.Items)
    {
        if (i.Value == row["MaterialTypeID"].ToString())
        {
            materialString = i.Text;
        }
    }
