    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton clickImageButton = sender as ImageButton;
        
        // This example assumes all the image buttons have the same parent.
        // Tweak as needed depending on the layout of your page
        Control parentControl = clickImageButton.Parent;
        List<ImageButton> allOtherImageButtons = parentControl.Controls.OfType<ImageButton>().AsQueryable().Where(i => i.ID != clickImageButton.ID).ToList();
        // Highlight
        clickImageButton.CssClass = "WhateverHighlights";
        // Unhighlight
        foreach (ImageButton button in allOtherImageButtons)
        {
            button.CssClass = "WhateverClears";
        }
    }
