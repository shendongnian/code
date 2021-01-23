    public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
    /// <summary>
        /// Update the relational StockKeepingUnitFeature table
        /// </summary>
        /// <param name="stockKeepingUnitSlug"></param>
        /// <param name="featureSlug"></param>
        /// <returns></returns>
        public bool AddFeatureToStockKeepingUnit(string stockKeepingUnitSlug, string featureSlug)
        {
            StockKeepingUnit sku = this.AllIncluding(stockKeepingUnit => stockKeepingUnit.Feature).Where(s => s.Slug == stockKeepingUnitSlug).FirstOrDefault();
            Feature feature = context.Features.FirstOrDefault(f => f.Slug == featureSlug);
            if (feature != null && sku != null)
            {
                sku.Feature.Add(feature);
                context.StockKeepingUnits.Attach(sku);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Update the relational StockKeepingUnitFeature database
        /// </summary>
        /// <param name="stockKeepingUnitSlug"></param>
        /// <param name="featureSlug"></param>
        /// <returns></returns>
        public bool RemoveFeatureFromStockKeepingUnit(string stockKeepingUnitSlug, string featureSlug)
        {
            StockKeepingUnit sku = this.AllIncluding(stockKeepingUnit => stockKeepingUnit.Feature).Where(s => s.Slug == stockKeepingUnitSlug).FirstOrDefault();
            Feature feature = context.Features.FirstOrDefault(f => f.Slug == featureSlug);
            if (feature != null && sku != null)
            {
                context.Entry(feature).Collection(s => s.StockKeepingUnit).CurrentValue = null;
                context.SaveChanges();
                return true;
            }
            return false;
        }
