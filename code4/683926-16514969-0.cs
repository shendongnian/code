           { this.Table("Employee");
            this.Id(
                x => x.Id,
                m =>
                    {
                        m.Generator(Generators.Sequence);
                    m.UnsavedValue(0);
                });
            this.Property(x => x.Surname, m => m.Column("surname"));
            this.ManyToOne(x => x.Boss, m => { m.Column("bossid");});
            this.Set(
               x => x.Subbord,
               collectionMapping =>
                   {
                       collectionMapping.Table("Employee");
                       collectionMapping.Cascade(Cascade.All);
                       collectionMapping.Inverse(true);
                       collectionMapping.Key(
                           k =>
                               {
                                  k.Column("bossid"); 
                                  
                                   k.ForeignKey("fk_Employee_BossEmployee");
                               });
                   },
            map => map.OneToMany());
        }
