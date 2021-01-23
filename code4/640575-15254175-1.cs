        public class EntityXConfiguration : BaseConfiguration<EntityX>
        {
            public EntityXConfiguration ()
            {
                ////Not needed here anymore. Moved to baseconfiguration
                //Property(x => x.Id).HasColumnName("EntityX_ID");
                //ToTable("tbl_X_EntityX");
                ////
                
                Property(x => x.ParentId).HasColumnName("EntityXParent_ID");
                Property(x => x.Name).HasColumnName("EntityXName");
               
    
                Ignore(x => x.EntityXProperty);
                ////Other mappings...
            }
        }
