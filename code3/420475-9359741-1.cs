    class MotionVectors
    {
        MotionVector _instances[100];
        public void Free(MotionVector vector)
        {
            var index = 'search vector in _instances' 
            _instances[index].Inuse = false;
        }
        public MotionVector GetNewInstance()
        {
            var index = 'first free vector in _instances'
            _instances[index].Inuse = true;
            return _instances[index];
        }
    }
