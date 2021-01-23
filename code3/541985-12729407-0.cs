    DesignerTransaction designerTransaction = m_designHost.CreateTransaction("Add Page");
    try
    {
        Panel p = (Panel)m_designHost.CreateComponent(typeof(Panel));
        m_changeService.OnComponentChanging(mControl.MainPanel, TypeDescriptor.GetProperties(mControl.MainPanel)["Controls"]);
        ...
        ...
        //Add our Panel to our splitContainer Panel2's controls collection, etc
        ...
        m_changeService.OnComponentChanged(mControl.MainPanel, TypeDescriptor.GetProperties(mControl.MainPanel)["Controls"], null, null);
        
        //Use the selection service to select the newly added Panel
        m_selectionService.SetSelectedComponents(new object[] { p });
    }
    catch( Exception ex )
    {
         designerTransaction.Cancel();
    }
    finally
    {
         designerTransaction.Commit();
    }
