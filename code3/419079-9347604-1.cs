    /// <summary>
    /// Called when [back to project view].
    /// </summary>
    /// <param name="e">The e.</param>
    public void OnBackToProjectView(CancelEditProjectEvent e)
    {
       eventAggregator.GetEvent<SelectedProjectViewEvent>().Publish(new SelectedProjectViewEvent()
       {
           SelectedPorject = selectedProject
       });
 
       regionManager.RequestNavigate(WellKnownRegionNames.ProjectViewRegion, new System.Uri("ProjectDetailsView", System.UriKind.Relative));
     }
