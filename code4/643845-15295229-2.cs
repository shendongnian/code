    private void createCombo()
    {
        cmb = new ComboBox[5];
        for (int i = 0; i <= 3; ++i)
        {
            cmb[i] = new ComboBox();
            cmb[i].Text = "CodeCall!";
            cmb[i].Size = new Size(90, 00);
            cmb[i].Location = new Point(i+5, 0);
            pnl.Controls.Add(cmb[i]);
         }
    }
