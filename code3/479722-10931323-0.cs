    switch (tabName)
    {
        case "tab1":
            UC1_1.Visible = true;
            UC1_1.DataBind();
            UC1_2.Visible = false;
            break;
        case "tab2":
            UC1_1.Visible = false;
            UC1_2.Visible = true;
            UC1_2.DataBind();
            break;
    }
