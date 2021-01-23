    public class BaseConfiguration<T> : EntityTypeConfiguration<T>
        where T : class
    {
        public BaseConfiguration()
        {
            TableNameConvention();
            PrimaryKeyConvention();
        }
        private void TableNameConvention()
        {
            switch (typeof(T).Name)
            {
                case "entityA":
                    ToTable("vw_entityA");
                    break;
                case "entityB":
                    ToTable("tbl_entityB");
                    break;
                case "entityC":
                    Map(x => x.Requires("discriminatorColumn")
                            .HasValue(value)
                            .HasColumnType("dataType")
                            .IsRequired())
                            .ToTable("tblentityC");
                    break;
                
                default:
                    ToTable("tbl_X_" + typeof(T).Name);
                    break;
            }
        }
        private void PrimaryKeyConvention()
        {
            var type = typeof(T);
            var parm = Expression.Parameter(type, type.Name);
            var propExpression = Expression.Lambda<Func<T, int>>
                    (Expression.Convert(Expression.Property(parm, "Id"), typeof(int)), parm);
                
            switch (type.Name)
            {
                case "entityB":
                    Property(propExpression).HasColumnName("IdEntityB");
                    break;
                default:
                    
                    Property(propExpression).HasColumnName(type.Name + "_ID");
                    break;
            }
            
        }
        
    }
