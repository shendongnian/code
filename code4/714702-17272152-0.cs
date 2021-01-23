    private void TextChangedEventHandler(object sender, EventArgs e)
    {
       TextBox tb = sender as TextBox;
       if(tb != null){
           if(tb.Text.Length > 0){
            //set color
           }
           else{
             //set color
           }
       }
    }
    ...
    
    //Loop through your controls (textboxes) and set handler
    foreach(Control c in this.Controls){
        if(c is TextBox){
            c.TextChanged += TextChangedEventHandler;
        }
    }
