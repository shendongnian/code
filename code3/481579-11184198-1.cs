    private void btnLeft_Click(object sender, EventArgs e)
    {
        if (flowPanelItemCategory.Location.X <= xpos)
        {
            xmin = flowPanelItemCategory.HorizontalScroll.Minimum;
            if (flowPanelItemCategory.Location.X >= xmin)
            {
                xpos -= 100;
                flowPanelItemCategory.Location = new Point(xpos, 0);
            }
        }
    }
    
    private void btnRight_Click(object sender, EventArgs e)
    {
        if (flowPanelItemCategory.Location.X <= xpos)
        {
            xmax = flowPanelItemCategory.HorizontalScroll.Maximum;
            if (flowPanelItemCategory.Location.X < xmax)
            {
                xpos += 100;
                flowPanelItemCategory.Location = new Point(xpos, 0);
            }
        }
    }
