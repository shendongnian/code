    bool IsChauffeurUsed= dropDown.SelectedValue=="Yes" ? true :false;
    Session["IsChauffeurUsed"]= IsChauffeurUsed;
    
    //Your logic to compute total
    int totalValue = 0;
    totalValue = int.Parse(Session["price"].ToString()) *
                 int.Parse(Session["day"].ToString());
    
    //check if chaffeur service is used
    bool isChaffeurUsed = (bool) Session["IsChaffeurUsed"]; 
    
        if(isChaffeurUsed)
            {
            total += 30;
            }
    Label8.Text = (totalValue).ToString();
