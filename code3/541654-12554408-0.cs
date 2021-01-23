    foreach (var button in Controls.OfType<Button>()) // or do it in the VS properties
    {
        button.Click += button_Click;
    }
---
    private static void button_Click(object sender, EventArgs eventArgs)
    {
        switch (((Button)sender).Name)
        {
            // find a way to disambiguate.
        }
    }
