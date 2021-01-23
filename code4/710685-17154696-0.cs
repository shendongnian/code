    class Jim
    {
        private Func<Sally> _createSally.
    
        public Jim(Func<Sally> createSally)
        {
            _createSally = createSally;
        }
    
        public void ConsumeSally()
        {
            Sally sally = _createSally();
            /* ... */
        }
    }
