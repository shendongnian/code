    try
    {
        // making sure the lang is a calture
        System.Globalization.CultureInfo c = new System.Globalization.CultureInfo(lang);
    }
    catch
    {
        lang = Session["lang"].ToString();
    }
