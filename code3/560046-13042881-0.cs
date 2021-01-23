    private List<string> messages= new List<string>(){"Fruits", "Vegetables", "Grains", "Poultry"};
    private int clickCount = 0;
        
    protected void Button1_Click(object sender, EventArgs e)
    {
       MyTextBox.Text = messages[clickCount];
       clickCount++;
       if (clickCount == messages.Count)
          clickCount = 0;
    
    }
