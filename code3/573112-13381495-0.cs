    public bool Equals(Episode other)
    {
        return Number == other.Number &&
               CaseNote.Equals(other.CaseNote) &&
               Patient.Equals(other.Patient);
    }
    
    public override bool Equals(object other)
    {
        Episode castOther = other as Episode;
        if(castOther == null)
            return false;
        return this.Equals(castOther);
    }
    public override int GetHashCode()
    {
        //TODO: Implement using the members you used in "Equals(Episode other)"
        throw new NotImplmentedExecption();
    }
