    var table = new [] {
    		new { box = chkBold, style = FontStyle.Bold },
    		new { box = chkItalics, style = FontStyle.Italic },
    		new { box = chkUnderline, style = FontStyle.Underline }
    	};
    	
	foreach(var combo in table)
	{
	  if(combo.box.Checked) 
            lblPrompt.Font.Style |= combo.style;		
	}
