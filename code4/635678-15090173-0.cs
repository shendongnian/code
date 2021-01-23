        label.Text = "SomeText";
        label.ID = "lblMessage" + messageNumber;
        if (heading)
        {
            label.Attributes.Add("style", "font-weight: bold;")                
        }
        UpdatePanel1.ContentTemplateContainer.Controls.Add(label);
        plcHolder.Controls.Add(label);
        label.Focus();
