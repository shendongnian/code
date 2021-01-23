    protected void Page_Load(object sender, EventArgs e)
    {
       for (int i = 0; i < 64; i++)
       {
          GridSquare square = new GridSquare();
          square.Click += new EventHandler(gridSquare_Click);
          grid.Add(gridSquare);
       }
    }
    
    void gridSquare_Click(object sender, EventArgs e)
    {
       GridSquare square = (GridSquare)sender;
       // do something cool with the clicked square here
    }
