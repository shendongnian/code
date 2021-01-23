    private Matrix _projection;
    public Matrix Projection
    {
        get
        {
            return _projection;
        }
        protected set 
        {
            // Make sure that Matrix is a structure and not a class
            // override == and != operators in Matrix (and Equals and GetHashCode)
            // If Matrix has to be a class, use !_project.Equals(value) instead
            // Consider using an inaccurate compare here instead of == or Equals
            // so that calculation inaccuracies won't require recalculation
            if (_projection != value)
            {
                _projection = value;
                generateFrustum();
            }
        }
    }
