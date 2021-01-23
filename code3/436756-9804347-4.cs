    private void LinkClick(object sender, System.EventArgs e)
    {
        HtmlElement element = ((HtmlElement)sender);
        string id = element.Id;
        string href = element.GetAttribute("href");
        bCancel = true;
        MessageBox.Show("Link Was Clicked Navigation was Cancelled");        
    }
