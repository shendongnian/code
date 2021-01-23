        public static void WithKeywords<TEntityType>(this EntityTypeConfiguration<TEntityType> entityTypeConfiguration)
            where TEntityType : EntityBase, IKeywordedEntity
        {
            var rootExpression = Expression.Parameter(typeof (TEntityType));
            var expression = Expression.Property(rootExpression, "Keywords");
            entityTypeConfiguration.HasMany(Expression.Lambda<Func<TEntityType, ICollection<Keyword>>>(expression, rootExpression)).WithMany();
        }
