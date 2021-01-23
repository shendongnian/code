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
