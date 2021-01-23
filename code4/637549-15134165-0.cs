    _db.tbl_Localities.InsertOnSubmit(locality);
    bool isDuplicate = _db.tbl_Localities
                        .Any(x => x.Locality == txt_Locality.Text);
    if (isDuplicate)
    {
        pnl_Message.Visible = true;
        lbl_message.Text = " Duplicate entry!";
        txt_Locality.Text = "";
    }
    else
    {
        // Save
        // ====
        _db.SubmitChanges();
    }
