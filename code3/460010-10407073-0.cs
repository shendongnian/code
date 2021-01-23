    if (HttpContext.Current.Session["Cart"] != null)
    {
        DataTable shoppingcart = (DataTable)HttpContext.Current.Session["Cart"];
        
        foreach (DataRow row in shoppingcart.Rows)
        {
                String checktitle = row["Title"].ToString();
                int price = row["price"].ToString();
                int quantity = row["quantity"].ToString();
                if (title == checktitle)
                {
                    //do something
                }
                else
                {
                    
                    Session["Cart"] = cart.cartrow(shoppingcart,checktitle,price,quantity);
                    ShoppingCart.DataSource = Session["Cart"]  as DataTable();
                    ShoppingCart.DataBind();
                }
         }
    
     }
