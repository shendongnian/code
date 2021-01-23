    You need to redraw the dynamic control at every postback. so no need to check page 
    Ispostback. check your viewstate the data become available after postback or not.
    
    protected void Page_Load(object sender, EventArgs e)
    {
        log.WriteLog("Drawing the menu");
        drawMenu();
        
    }
    
    private void drawMenu()
    {
            if (ViewState["SubjectList"] != null)
            {
                subjList = (ArrayList)ViewState["SubjectList"];
            }
            for (int i = 0; i < subjList.Count; i++)
            {
                    MenuItem item = new MenuItem();
                    item.Text = subjList[i].ToString();
                    item.Value = i.ToString();
                    NavigationMenu.Items.Add(item);
            }
    }
