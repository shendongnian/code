    var autoExpand = Observable.FromEventPattern<DragEventArgs>(tree, "DragOver");
    
    autoExpand
        .Select(dragEvent => tree.GetNodeFromCoordinates(dragEvent.EventArgs.X, dragEvent.EventArgs.Y))
        .DistinctUntilChanged()
        .Throttle(TimeSpan.FromSeconds(1))
        .ObserveOn(SynchronizationContext.Current)
        .Subscribe(node => {
                if (node != null) node.Expand();
            });
