    public bool AllInactive
    {
        get
        {
            foreach (UserRow ur in Users)
            {
                if (ur.Status <> 1) return true;
            }
            return false;
        }
    }
