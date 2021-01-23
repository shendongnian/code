    bool isNotValid= false;
    foreach (DataListItem dli in list.Items)
    {
        int qty = Convert.ToInt32(((TextBox)dli.FindControl("qtyTextBox")).Text);
        int productID = Convert.ToInt32(((Literal)dli.FindControl("prodId")).Text);
        
        isQtyValid = COMMONACES.GetValues.getTotalQty(sessionID, productID, qty);
        
        lblError.Visible = !isQtyValid;
        lblError.Text = isQtyValid ? string.Empty : "The total quantity for one or more items exceeds the maximum. The total quantity includes items already in the cart.";
        if(!isQtyValid)
            isNotValid=true;
    }
    Page.ClientScript.RegisterStartupScript(this.GetType(), "function", string.Format("SetButtonStatus('{0}')", isNotValid.ToString().ToLower()) , true); //used to access javascript
    function SetButtonStatus(isNotValid) {
        var bb = document.getElementsByClassName('ButtonSubmit');
        for (var i = 0; i < bb.length; i++) {
            bb[i].disabled = isNotValid;
        }
    }
