    protected void PopulateControls()
    {
        for (int a = 0; a < 10; a++)
        for (int b = 0; b < 14; b++)
        {
            var btn = new Button();
            btn.ID = "Btn_" + a + "_" + b;
            MyButtonPanel.Controls.Add(btn);
        }
    }
