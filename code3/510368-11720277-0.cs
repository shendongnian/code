        List<int> newCart;
        if (e.CommandName == "AddToCart")
        {
            var arg = e.CommandArgument;
            DropDownList ddlList = e.Item.FindControl("ddlAvailableSizes" + e.CommandArgument) as DropDownList;
            int currentItemID = int.Parse(this.dlstCartItems.DataKeys[e.Item.ItemIndex].ToString());
            if (ddlList.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please Select Size');", true);
            }
            else
            {
                if (Session["Cart"] == null)
                {
                    newCart = new List<int>();
                    newCart.Add(Convert.ToInt32(e.CommandArgument));
                    Session["Cart"] = newCart;
                }
                else
                {
                    newCart = Session["Cart"] as List<int>;
                    newCart.Add(Convert.ToInt32(e.CommandArgument));
                    Session["Cart"] = newCart;
                }
                int ct = ((List<int>)Session["Cart"]).Count;
                lblCartMessage.Text = Convert.ToString(ct) + " " + "Product";
            }
        }
    }
