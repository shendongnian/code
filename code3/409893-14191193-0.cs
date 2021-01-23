    PartContainer = (Grid)this.GetTemplateChild("PART_Container");
    cvv = (PartContainer).Children[2] as CollectionViewerView;
            
    if (cvv != null)
    {
        cvvm = ViewBehaviors.GetViewModel(cvv);
        Grid container = cvv.Content as Grid;
        Border viewerBorder = container.Children[1] as Border;
        Grid cvGrid = viewerBorder.Child as Grid;
        cvc = cvGrid.Children[0] as CollectionViewContainer;
    }
