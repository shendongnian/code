    if (!Page.IsPostBack)
        { 
            Response.Cookies["Infoscreen_Anzeigeeinstellungen_Ausgewählte_Abteilung"].Value =  ausgewählte_Abteilung.ToString(); 
        }
        else
        { 
            ausgewählte_Abteilung = Request.Cookies["Infoscreen_Anzeigeeinstellungen_Ausgewählte_Abteilung"].Value; 
        }
