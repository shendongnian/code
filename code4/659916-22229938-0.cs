    Label lblParaname = new Label();
    lblParaname.Text = Record.Parameter_Name + ": ";
    lblParaname.ID = "lbl" + Record.Parameter_Name;
    lblParaname.EnableViewState = true;
    lblParaname.Attributes.Add("cssclass", "grid_3 alpha omega");
    Panel pLblContainer = new Panel();
    pLblContainer.CssClass = "grid_3";
    pLblContainer.Controls.Add(lblParaname);
    pSubsPar.Controls.Add(pLblContainer);
`
