    rotected void Page_Load(object sender, EventArgs e)
    {
       string buttonName;
       try
       {   
          ...
          CreateButton(transID, buttonName); // Pass transID          
          ...
       } 
    }
    
    private void CreateButton(int transID, string buttonName)
    {
      transbutton = new Button();
      transbutton.Text = buttonName;
      transbutton.ID = transID.ToString(); // ID is required
      ...
    }
