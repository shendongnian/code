    public void AuditableCreated(IAuditable auditable)
    {
        auditable.CreatedDate = DateTime.Now;
    }
    public void AuditableUpdated(IAuditable auditable)
    {
        auditable.UpdatedDate = DateTime.Now;
    }
