    protected void cmdCerca_Click(object sender, EventArgs e)
    {
        foreach (HiddenField hf in panelCategorieGuida.Controls.OfType<HiddenField>())
        {
            if (String.Equals(hf.Value, "1"))
            {
                HtmlGenericControl div = hf.Parent as HtmlGenericControl;
                if (div == null)
                {
                    //some handling here
                }
                div.Attributes["class"] = "option-box-selected";
            }
        }
    }
