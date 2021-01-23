    for (int i = 0; i < BulletedList1.Items.Count; i++)
    {
            if (i % 2 == 0)
            {
                BulletedList1.Items[i].Attributes.CssStyle.Value = "href";
            }
            else
            {
                BulletedList1.Items[i].Attributes.CssStyle.Value = "other";
            }
    }
