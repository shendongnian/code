    foreach (Control c in panPrev.Controls)
    {
        if (c.Name.StartsWith("cbGuns"))
        {
            c.Items.AddRange(arr);
        }
    }
