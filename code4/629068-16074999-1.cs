    foreach (Microsoft.Office.Tools.Outlook.IFormRegion formRegion in Globals.FormRegions)
    {
        if (formRegion is FormRegion1)
        {
            FormRegion1 formRegion1 = (FormRegion1)formRegion;
            formRegion1.OutlookFormRegion.Visible = false;
        }
    }
