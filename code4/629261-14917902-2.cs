        Label L = new Label();
        L.ID = "txt" + i;
        L.Text = dr["category_name"].ToString();
        L.CssClass = "heading";
        divCat.Controls.Add(L); 
        L.ClientIDMode= ClientIDMode.Static;
