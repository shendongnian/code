    var measure = new MeasureAction();
    measure.TargetObject = _mapControl;
    measure.MeasureMode = MeasureAction.Mode.Polyline;
    measure.MapUnits = DistanceUnit.Miles; 
    ManualTrigger trigger = new ManualTrigger();
    trigger.Actions.Add(measure);
    trigger.Invoke(null);
