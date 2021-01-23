        protected IQueryable<StockTakePipeline> GetPipelineState(InventoryModelDataContext context)
        {
            return from pe in context.StockTakePipelines
                    where pe.StockTakeId == null
                    select pe;
        }
        protected void SavePipelineState()
        {
            using(InventoryModelDataContext context = new InventoryModelDataContext(this.ConnectionString));
            {
              foreach (StockTakePipeline p in GetPipelineState(context))
              {
                  p.StockTakeId = this.StockTakeId;
              }
              context.SubmitChanges();
            }
        }
