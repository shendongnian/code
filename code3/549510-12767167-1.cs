    Panel container = new Panel();
    //example, use whatever do you need
    container = new Size(100, 100);
    container = new Position(0, 0);
    //add the panel to the form
    this.Controls.Add(container);
     
    //set the pictureboxes here...
    //Add the pictureboxes to the panel
    container.Controls.AddRange(new Control[]{p1, p2, p3}); //and so on
    
    //Then when you need to show them
    container.Visible = true; //false to hide them
