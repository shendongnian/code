        protected void ExecutePostAccountCreate(LocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new ArgumentNullException("localContext");
            }
            IPluginExecutionContext context = localContext.PluginExecutionContext;
            Entity postImageEntity = (context.PostEntityImages != null && context.PostEntityImages.Contains(this.postImageAlias)) ? context.PostEntityImages[this.postImageAlias] : null;
            // TODO: Implement your custom Plug-in business logic.
            //create a data context - DataContext is the name I use - it might be different depending on your usage of crmsvcutil!
            var ctx = new DataContext(localContext.OrganizationService);
            //use the post image to get a strongly typed object
            //you can use aEntity to get whatever information you need for updating other entities
            var aEntity = postImageEntity.ToEntity<new_A>();
            //get the related entities (add System.Linq to using!)
            //I'm assuming the relationship is A (1:N) B
            var bEntities = ctx.new_bSet.Where(e => e.new_aId.Id == aEntity.Id).ToArray();
            foreach (var bEntity in bEntities)
            {
                //set values for each of the entities here
                //for example: bEntity.new_field1 = aEntity.new_fieldBase;
                ctx.UpdateObject(bEntity);
            }
            ctx.SaveChanges();
        }
