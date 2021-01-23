    richTextBox.PreviewKeyDown += (sender2, e2) =>
    {
    	if (e2.Key == Key.PageUp)
    	{
    		richTextBox.Focus();
            //Use Code to Scroll Up 6 Lines  
    		for (int j = 0; j < 6; j++)  
    			EditingCommands.MoveUpByLine.Execute(null, richTextBox);
    		e2.Handled = true;
    	}
    	if (e2.Key == Key.PageDown)
    	{
            richTextBox.Focus();
            //Use Code to Scroll Down 6 Lines
    		for (int j = 0; j < 6; j++)    
    			EditingCommands.MoveDownByLine.Execute(null, richTextBox);
    		e2.Handled = true;
    	}
    };
