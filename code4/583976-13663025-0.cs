    protected void Button1_Click(object sender, EventArgs e)
    {
        Label l1 = new Label();
        l1.ID = "label1";
        l1.Text = "this is it...";
        up.ContentTemplateContainer.Controls.Add(l1); 
    
        up.Update();     
    }
