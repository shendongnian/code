    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode(ContactName) ^
            StringComparer.OrdinalIgnoreCase.GetHashCode(Company) ^
            // ...
            StringComparer.OrdinalIgnoreCase.GetHashCode(Zip);
    }
