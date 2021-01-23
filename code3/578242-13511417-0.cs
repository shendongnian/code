    Button btnLoad = (Button)e.Item.FindControl("btnLoad");
    foreach (Control c in e.Item.Controls)
        {
            if (b is Button)
            {
                if(b == btnLoad)
                 {
                 b.Enabled = false;
                 }
                else
                 {
                 b.Enabled = true;
                 }
            }
        }
