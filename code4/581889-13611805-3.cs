    this.Deactivated += new EventHandler<DeactivationEventArgs>(WorkspaceViewModel_Deactivated);
    void WorkspaceViewModel_Deactivated(object sender, DeactivationEventArgs e)
    {
        if(e.WasClosed) MainConductor.EventAggregator.Publish(new ActivateWindowMessage(typeof(SomeVM));
    }
