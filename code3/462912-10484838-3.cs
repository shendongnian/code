    protected void cmdCerca_Click(object sender, EventArgs e)
    {
        foreach (HtmlGenericControl div in panelCategorieGuida.Controls.OfType<HtmlGenericControl>())
        {
            HiddenField hf = div.Controls.OfType<HtmlGenericControl>()[0]; //leaving out all the exceptions handling
            if (String.Equals(hf.Value, "1"))
            {
                div.Attributes["class"] = "option-box-selected";
            }
        }
    }
