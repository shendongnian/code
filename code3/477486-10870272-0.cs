    //Create panels dynamically
    for(int i=0;i<dataTable.Rows.Count.i++)
    {
         Panel p=new Panel();
         p.Name="panelDay_" + i;
         //Write code to set panels location and size
         //Add panel to the panels parent
         parentPanel.Controls.Add(p);
    }
    //Now access panel with the name
    parentPanel.Controls["panelDay_" + i].Color=Color.Blue;
