    private void Form1_Shown(Object sender, EventArgs e) {
    	string word = "1.4";
    
    	var url = "http://chipperyman573.com/rtf/textbot.html";
    	var client = new WebClient();
    	
    	client.DownloadStringCompleted += (sender, e) => 
    	{
    	   if(e.Error != null)
    	   {
    			//Maybe do some error handling?
    	   }
    	   else
    	   {
    			if (e.Result == word)
    			{
    				update = false;
    				MessageBox.Show("Congrats! You are running the latest version (" + word + ") of Chip Bot!\n\nGot an idea for this program? Use the \"Send feedback\" button to let me know!", "Chip Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
    				Text = "Chip Bot" + word + " - Got an idea for this program? Send me some feedback!";
    			}
    			else
    			{
    				Text = "Chip Bot (UPDATE AVAILABLE)";
    				go.ForeColor = Color.Gray;
    				setup.Enabled = false;
    				otherGroup.Enabled = false;
    				optionsGroup.Enabled = false;
    				MessageBox.Show("There is an update! Downloading now! \n\nUNTIL YOU UPDATE THE PROGRAM WILL NOT FUNCTION.", "Chip Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
    				url = "";
    				var web = new WebBrowser();
    				web.Navigate(url);
    			}
    	   }
    	};
    	
    	client.DownloadStringAsync(url);	
    }
