    public List<A> GetA(int AID, string AName, bool? isActive, bool? isMax)
    {
        return Context.A
                .Where(c =>
                           (AID <= 0 || c.AID == AID)
                        && (string.IsNullOrEmpty(AName) || c.Name.Contains(AName))
                        && (isActive == null || c.IsActive == isActive)
                        && (isMax == null || c.B.Any(b => IsMax == isMax))
                      )
                .ToList();
    }
