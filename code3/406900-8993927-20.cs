    result = controls.Delimit(
        null, // no separator
        (current) => {
            var textbox = current as System.Web.UI.WebControls.TextBox;
            if (textbox == null)
                return null;
            // prefix all TextBox controls with a <label> element
            var label = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
            label.Attributes["for"] = textbox.ClientID;
            label.InnerText = textbox.Attributes["name"];
            return label; },
        null); // no suffix
