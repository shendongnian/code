    int i = 0;
    if (Int32.TryParse (textbox.Text, out i)) 
    {
        // i is good here
    }
    else 
    {
        // i is BAD here, do something about it, like displaying a validation message
    }
    
