    #region Invariants
    [ContractInvariantMethod]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        "CA1822:MarkMembersAsStatic",
        Justification = "Required for code contracts.")]
    private void ObjectInvariant()
    {
        Contract.Invariant(this.blah != null);
    }
    #endregion
