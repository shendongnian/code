    var measure = new MeasureAction();
    measure.TargetObject = _mapControl;
    measure.MeasureMode = MeasureAction.Mode.Polyline;
    measure.MapUnits = DistanceUnit.Miles; 
    measure.Invoke();
