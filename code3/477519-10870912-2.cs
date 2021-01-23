    private Matrix _projection = null;
    public Matrix Projection
    {
        get { return _projection; }
        protected set 
        {
            _projection = value;
            generateFrustum();
        }
    }
