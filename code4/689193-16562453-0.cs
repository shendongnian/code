    public override int GetHashCode()
    {      
        int hashClaimId = this.ClaimId == null ? 0 : this.ClaimId.GetHashCode();
        int hashFirstname = this.Firstname == null ? 0 : this.Firstname.GetHashCode();
        int hashLastname = this.Lastname == null ? 0 : this.Lastname.GetHashCode();
        return 31*31*hashClaimId + 31*hashFirstname ^ hashLastname;
    }
