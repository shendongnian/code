    protected override void OnViewLoaded(object view)
    {
        base.OnViewLoaded(view);
        this._model = (PlotModel)((XXXView)view).FindResource("TestPlotModel");
    }
