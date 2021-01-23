    var L = new Label();
    L.ID = "txt" + i;
    L.Text = dr["category_name"].ToString();
    L.CssClass = "heading myLabel"; // Set multiple classes separated by spaces
    divCat.Controls.Add(L); 
