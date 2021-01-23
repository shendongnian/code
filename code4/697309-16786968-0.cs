        protected void btn_Click(object sender, EventArgs e)
    {
        TextBox textName;
        textName = new TextBox();
        textName.TextChanged += new EventHandler(textName_TextChanged);
        string divContect = ControlRenderer(divTextBox);
        divTextBox.InnerHtml = divContect + ControlRenderer(textName);
    }
    protected void textName_TextChanged(object sender, EventArgs e)
    {
    }
    public string ControlRenderer(Control control)
    {
        StringWriter writer = new StringWriter();
        control.RenderControl(new HtmlTextWriter(writer));
        return writer.ToString();
    } 
