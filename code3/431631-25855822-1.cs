       LinkButton linkButton = (LinkButton)e.Row.FindControl("lbtVisualizar");
       linkButton.Text = "Test";
       linkButton.CommandArgument = "Download";
       ImageButton imbVisualizar = (ImageButton)e.Row.FindControl("imbVisualizar");
       imbVisualizar.CommandArgument = "Download";
       linkButton.Attributes.Add("href", "javascript: $(" + imbVisualizar.ClientID + ").click();");
