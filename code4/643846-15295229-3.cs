    private void createCombo()
    {
        cmb = new ComboBox[5];
        int width = 90;
        int height = 25;
        int spacing = 5;
        for (int i = 0; i <= 3; ++i)
        {
            ComboBox newBox = new ComboBox();
            newBox.Text = "CodeCall!";
            newBox.Size = new Size(width, height);
            newBox.Location = new Point((i*width)+spacing, 0);
            cmb[i] = newBox;
            pnl.Controls.Add(newBox);
         }
    }
