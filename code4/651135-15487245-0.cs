    //class level variable
    List<Panel> allPanels = new List<Panel>();
  
    //...   
   
    Panel pnl1 = new Panel();
    //...panel code
    this.Controls.Add(pnl1);
    allPanels.add(pnl1);
   
    Panel pnl2 = new Panel();
    //...panel code
    this.Controls.Add(pnl2);
    allPanels.add(pnl2);
    //..
    private void button1_Click(object sender, EventArgs e)
    {
        foreach(Panel p in allPanels)
             p.Controls.Clear();
    }
