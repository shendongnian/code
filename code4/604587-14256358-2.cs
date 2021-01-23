    OtherEntityCollection : Collection<OtherEntity>
    {
        protected override void InsertItem(int index, OtherEntity item)
        {
            // do your validation here
            base.InsertItem(index, item);
        }
    
        // other overrides
    }
