    protected void PopulateControls()
    {
        for (int a = 0; a < 10; a++)
        for (int b = 0; b < 14; b++)
        {
            var btn = new Button();
            btn.ID = "Btn_" + a + "_" + b;
            // add an event handler for the click-event
            btn.Click += buttonHandler;
            MyButtonPanel.Controls.Add(btn);
        }
    }
