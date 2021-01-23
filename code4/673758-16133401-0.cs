    protected void ListView2ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
      using (var myEntities = new i96X_utilEntities())
      {
        var myPlotColour = (from plotC in myEntities.PlotColours
                            where plotC.ID == selectedID
                            select plotC).Single();
        myPlotColour.PlotColour1 = ColourChosen.Value;
        myEntities.SaveChanges();
      }
    }
