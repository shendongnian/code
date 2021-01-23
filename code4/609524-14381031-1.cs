    _map.Dispatcher.BeginInvoke((Action)(() =>
    {
        _map.Children.Clear();
        foreach (var projectedPin in pinsToAdd.Where(pin => PointIsVisibleInMap(pin.ScreenLocation, _map)))
        {
            _map.Children.Add(projectedPin.GetElement(ClusterTemplate));
        }
    }));
