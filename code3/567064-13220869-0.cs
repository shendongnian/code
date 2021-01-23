    public IEnumerable<IPerson> Members
    {
        get
        {
            return DoctorMembers.Cast<IPerson>();
        }
    }
