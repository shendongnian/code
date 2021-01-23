    public T this[int i]
    {
        get
        {
            switch(i)
            {
                case 0: return BirthNo;
                default: throw new ArgumentException("i");
            }
        }
    }
