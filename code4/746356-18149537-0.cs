    public class AuditableModelBaseMap : EntityTypeConfiguration<AuditableModelBase>
    {
        public AuditableModelBaseMap()
        {
            this.HasRequired(amb => amb.CreatedByUserProfile).WithMany().HasForeignKey(amb => amb.CreatedByUserId).WillCascadeOnDelete(false);
            this.HasRequired(amb => amb.UpdatedByUserProfile).WithMany().HasForeignKey(amb => amb.UpdatedByUserId).WillCascadeOnDelete(false);
        }
    }
