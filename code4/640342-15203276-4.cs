    public class Bill
        {
            public int ID { get; set; }
            public int BillTypeID { get; set; }
            public string UserName { get; set; }
            public DateTime Time { get; set; }
        }
    
        public class BillItem
        {
            public int ID { get; set; }
            public int ItemID { get; set; }
            public string UserName { get; set; }
            public DateTime Time { get; set; }
        }
    
        internal class BillMap : EntityTypeConfiguration<Bill>
        {
            public BillMap()
            {
                ToTable("Bills");
                HasKey(x => x.ID);
                Property(x => x.ID).HasColumnName("BillId");
                Property(x => x.BillTypeID).IsRequired().HasColumnName("BillTypeId");
                Property(p => p.UserName).IsRequired().HasColumnName("Usr");
                Property(x => x.Time).IsRequired().HasColumnName("Tm");
            }
        }
    
        internal class BillItemMap : EntityTypeConfiguration<BillItem>
        {
            public BillItemMap()
            {
                ToTable("BillItems");
                HasKey(x => x.ID);
                Property(x => x.ID).HasColumnName("BillItemId");
                Property(x => x.ItemID).IsRequired().HasColumnName("ItemId");
                Property(p => p.UserName).IsRequired().HasColumnName("Usr");
                Property(x => x.Time).IsRequired().HasColumnName("Tm");
            }
        }
