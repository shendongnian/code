    if (HttpContext.Current.Session["Cart"] != null)
    {
        DataTable shoppingcart = (DataTable)HttpContext.Current.Session["Cart"];
        //put here each row you need to bind
        DataTable toBind = new DataTable();  //do more to init the columns, rows, etc
        for (int i = 0; i < shoppingcart.Rows.Count; i++)
        {
            String checktitle = shoppingcart.Rows[i]["Title"].ToString();
                if (title == checktitle)
                {
                    //do something
                }
                else
                {
                    toBind.add(cart.cartrow(shoppingcart));  //the sintax here is incorect, I code directly here
                    //ShoppingCart.DataSource = cart.cartrow(shoppingcart);
                    //ShoppingCart.DataBind();
                }
            }
            //bind outside the for cicle
            ShoppingCart.DataSource = toBind ;
            ShoppingCart.DataBind();
        }
    
        else
        {
            HttpContext.Current.Session["Cart"] = cart.shoppingCart();
            ShoppingCart.DataSource = cart.shoppingCart();
            ShoppingCart.DataBind();
        }
    
    }  
