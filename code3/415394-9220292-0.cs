    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        if (DatabaseConnection.TryGetField(binder.Name, out result))
            return true;
        // Log the database failure here
        result = null;
        return false; // The attempt to get the member fails at runtime
    }
