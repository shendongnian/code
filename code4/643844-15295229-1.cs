    private void createCombo()
    {
        cmb = new ComboBox[5];
        for (int i = 0; i <= 3; ++i)
        {
            ComboBox newBox = new ComboBox();
            newBox.Text = "CodeCall!";
            newBox.Size = new Size(90, 00);
            newBox.Location = new Point(i+5, 0);
            cmb[i] = newBox;
            pnl.Controls.Add(newBox);
         }
    }
