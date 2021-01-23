        public MapeamentoParent()
        {
            Id(_ => _.Id, "PARENT_ID").GeneratedBy.Identity();
            HasMany<Child>(_ => _.Children)
                .Inverse()
                .AsSet()
                .Cascade.All()
                .Not.OptimisticLock()
                .KeyColumn("PARENT_ID");
        }
