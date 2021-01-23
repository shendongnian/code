    // Retrieve selected lines
    List<string> SelectedLines = Regex.Split(txtNewURLs.SelectedText, @"\r\n").ToList();
    // Check for nothing, Regex.Split returns empty string when no text is inputted
    if(SelectedLines.Count == 1) {
    	if(String.IsNullOrWhiteSpace(SelectedLines[0])) {
    		SelectedLines.Remove("");
    	}
    }
    // Retrieve all lines from textbox
    List<string> AllLines = Regex.Split(txtNewURLs.Text, @"\r\n").ToList();
    // Check for nothing, Regex.Split returns empty string when no text is inputted
    if(AllLines.Count == 1) {
    	if(String.IsNullOrWhiteSpace(AllLines[0])) {
    		AllLines.Remove("");
    	}
    }
    string SelectedMessage = "The following lines have been selected";
    int numSelected = 0;
    // Find all selected lines
    foreach(string IndividualLine in AllLines) {
        if(SelectedLines.Any(a=>a.Equals(IndividualLine))) {
            SelectedMessage += "\nLine #" + AllLines.FindIndex(a => a.Equals(IndividualLine));
            // Assuming you store each line status in an List, change status to 1
            LineStatus[AllLines.FindIndex(a => a.Equals(IndividualLine));] = 1;
    	   numSelected++;
        }
    }
    MessageBox.Show((numSelected > 0) ? SelectedMessage : "No lines selected.");
