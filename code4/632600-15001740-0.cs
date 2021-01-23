    public static void BindComboBox<T>(DropDownList listName, List<T> list, string textField, string valueField)
    {
        listName.DataTextField = textField;
        listName.DataValueField = valueField;
        listName.DataSource = list;
        listName.DataBind();
    }
