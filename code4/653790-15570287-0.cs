    private class LivingBindingList : BindingList<Producer>
    {
        public LivingBindingList(List<Producer> source)
            : base(source.Where(producer => producer.ChangeTracker.State != ObjectState.Deleted).ToList())
        {
            rem_cache = source.Where(producer => producer.ChangeTracker.State == ObjectState.Deleted).ToList();
        }
        List<Producer> rem_cache;
        protected override void RemoveItem(int index)
        {
            this.Items[index].MarkAsDeleted();
            this.rem_cache.Add(this.Items[index]);
            base.RemoveItem(index);
        }
        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            e.NewObject = new Producer()
            {
                NameProducer = "Новый производитель",
                GUID = Guid.NewGuid(),
                Type = 1,
                Note = String.Empty
            };
            base.OnAddingNew(e);
        }
        internal IEnumerable<Producer> GetAllForSubmit()
        {
            return this.Items.Concat(rem_cache);
        }
    }
