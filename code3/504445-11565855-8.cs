    private class EstablishmentNodeOrm : EntityTypeConfiguration<EstablishmentNode>
    {
        internal EstablishmentNodeOrm()
        {
            ToTable(typeof(EstablishmentNode).Name);
            HasKey(p => new { p.AncestorId, p.OffspringId });
        }
    }
