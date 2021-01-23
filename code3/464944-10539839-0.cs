    for (int i = 0; i < GridFactures.Rows.Count; i++)
    {
        Control ctrl = GridFactures.Rows[i].Cells[6].FindControl("lblMontantTTC");
        if (ctrl != null)
        {
            Label lbl = ctrl as Label;
            if (lbl != null)
            {
                total += Convert.ToDouble(lbl.Text);
            }
        } 
    }
