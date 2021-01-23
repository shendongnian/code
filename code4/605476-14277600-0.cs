    for (int i = 0; i < 99; i++)
    {
        chck[i] = new CheckBox();
        chck[i].ID = string.Format("chk_1_{0}", i);
        chck[i].Text = chck + Convert.ToString(i);
        pnlcom1.Controls.Add(chck[i]);
        pnlcom1.Controls.Add(new LiteralControl("<br />"));
        chckbx[i] = new CheckBox();
        chck[i].ID = string.Format("chk_2_{0}", i);
        chckbx[i].Text = chckbx + Convert.ToString(i);
        pnlcom2.Controls.Add(chckbx[i]);
        pnlcom2.Controls.Add(new LiteralControl("<br />"));
    }
