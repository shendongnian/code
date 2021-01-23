    foreach (Object obj in Objects)
    {
        HtmlGenericControl div = new HtmlGenericControl("div");
        div.Attributes["class"] = "option-box";
        HiddenField hf = new HiddenField();
        hf.Value = "0";
        hf.ID = "category" + obj.ID;
        div.Controls.Add(hf);
        panelCategorieGuida.Controls.Add(div);
    }
