    private SkeletonPoint _jointInitial;
    private bool _initialized;
    void MyMethodThatProcessesJoints(Joint joint)
    {
        if (!_initialized)
        {
            _jointInitial = joint.Position;
            _initialized = true;
        }
        else
        {
            var pos = joint.Position;
            
            var dx = pos.X - _jointInitial.X;
            var dy = pos.Y - _jointInitial.Y;
        
            var distance = Math.Sqrt(dx * dx + dy * dy);
            // do something with distance...
        }       
    }
