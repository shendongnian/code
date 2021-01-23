    class UnloggedException : Exception
    {
        public UnloggedException(Exception innerException)
            : base(innerException.Message, innerException)
        {   
        }
    }
