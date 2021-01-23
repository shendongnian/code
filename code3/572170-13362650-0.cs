    private void Canvas_Drop(object sender, DragEventArgs e)
    {
        bool itemIsTextbox = (e.Data.GetDataPresent(typeof(TextBox)) == true);
        
        //get the textbox then get hte text out of it
        if (itemIsTextbox)
            string text = (TextBox)e.Data.GetData(typeof(TextBox)).Text;
    }
