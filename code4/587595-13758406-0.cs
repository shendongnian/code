    foreach (var snacks in gvSnackCart.Rows.GroupBy(snack => snack.Cells[1].Text.ToString()))
    {
        var p = myCommand.Parameters;
        // I'm largely guessing at these, but hopefully you get the idea.
        p.Add("@shopperID"      , SqlDbType.NVarChar).Value = txtCurrentUser.Text;
        p.Add("@itemName"       , SqlDbType.NVarChar).Value = snacks.Key;
        p.Add("@itemType"       , SqlDbType.NVarChar).Value = /* ??? */;
        p.Add("@quantityOrdered", SqlDbType.Int     ).Value = snacks.Count();
        p.Add("@unitPrice"      , SqlDbType.Money   ).Value = snacks.Sum(r => r.SnackPrice);
        …
    }
