    // Dictionary to save values
    Dictionary<string, int> dict = new Dictionary<string, int>();
    // Method that is called on user submit button click
    private void HandleSubmit(object sender, EventArgs args) {
        // Add values of both textboxes to dictionary
    	dict.Add(textBox1.Text, Int32.Parse(textBox2.Text));
        
        // Check if all data is entered
        // then activate custom method
        if(dict.Count >= 100) {
            CUSTOMMETHOD(dict);
        }
    }
