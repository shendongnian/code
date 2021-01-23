    foreach(string i in id_items)
    {
        HtmlGenericControl liItem = (HtmlGenericControl)navigation.FindControl(i);
        if (liItem != null)
        {
            if (menu_Item_Fondo != null)
                liItem.Style["background-color"] = menu_Item_Fondo;
            if (menu_Item_Hover_Fondo != null)
            {
                StringBuilder style = new StringBuilder();
                style.AppendLine(".navigation li a:hover { ");
                style.AppendLine(String.Format(" color: {0};", menu_Item_Hover_TextColor));
                style.AppendLine(String.Format(" background-color: {0};", menu_Item_Hover_Fondo));
                style.AppendLine("} ");
                style_menu_item.InnerText = style.ToString();
            }
        }
    }
