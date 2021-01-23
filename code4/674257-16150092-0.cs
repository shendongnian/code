    bool scrap;
    bool production;
    bool change;
    foreach (DataRow row in dtresults.Rows)
    {
        scrap = (bool)row["btnscrap"];
        if (scrap)
        {
            btnSREntry.Show();
        }
        else
        {
            btnSREntry.Hide();
        }
        production = (bool)row["btnproduction"];
        if (production)
        {
            btnProductionEntry.Show();
        }
        else
        {
            btnProductionEntry.Hide();
        }
        change = (bool)row["btnchange"];
        if (change)
        {
            btnSRChange.Show();
        }
        else
        {
            btnSRChange.Hide();
        }
    } 
