    void Page_Load(object sender, EventArgs e)
    {
        if(checkDisplayCount.Checked)
        {
            String scriptText = "";
            scriptText += "function DisplayCharCount(){";
            scriptText += "   spanCounter.innerText = " + 
                " document.forms[0].TextBox1.value.length";
            scriptText += "}";
            ClientScriptManager.RegisterClientScriptBlock(this.GetType(), 
               "CounterScript", scriptText, true);
            TextBox1.Attributes.Add("onkeyup", "DisplayCharCount()");
            LiteralControl spanLiteral = new 
                LiteralControl("<span id=\"spanCounter\"></span>");
            PlaceHolder1.Controls.Add(spanLiteral);
        }
    }
