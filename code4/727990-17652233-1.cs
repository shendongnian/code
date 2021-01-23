    This is because you have just wrote ONLY to uncheck the checkboxes in the pageload and not to disable the controls  behind the checkbox; If thats needed, then your snippet in the pageload should be:
        
          if (!Page.IsPostBack)
                {
                    ChckOrdType.Checked = false;
                    ChkPlntPric.Checked = false;
                    ChkExcluBro.Checked = false;
                    ......
                    .....
                   ddlOrdType.Enabled = false; 
                   ddlPlntPric.Enabled = false;
                   ddlExcluBroker.Enabled = false;  
                   .........
        
                }
    
    
    or 
    
     if (!Page.IsPostBack)
                {
                    ChckOrdType.Checked = false;
                    ChkPlntPric.Checked = false;
                    ChkExcluBro.Checked = false;
                    ......
                    .....
                  
    ChckOrdType_CheckChanged(sender,e);
    chkPlntPric_CheckChanged(sender,e);
    chkExcluBro_CheckChanged(sender,e);
    ...
    
        
                }
