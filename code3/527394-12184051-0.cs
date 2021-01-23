    public class EventGroupIDLayerTuple : Tuple<Int32, Layer>
    {
        public EventGroupIDLayerTuple(Int32 EventGroupID, Layer Layer) : base(EventGroupID, Layer) { }
        public Int32 EventGroupID { get { return this.Item1; } }
        public Layer Layer { get { return this.Item2; } }
    }
    public class EventGroupLayerResult
    {
        public Int32 EventGroupID { get; set; }
        public Layer Layer { get; set; }
        //Computed Values
        public Decimal Sum { get; set; }
        public Decimal Average { get; set; }
        //...
    }
    /// <summary>ObservableCollection of computed EventGroup/Layer results that are also indexed
    /// in a dictionary for rapid retrieval.</summary>
    public class EventGroupLayerResultCollection : ObservableCollection<EventGroupLayerResult>
    {
        Dictionary<EventGroupIDLayerTuple, EventGroupLayerResult> _Index = 
            new Dictionary<EventGroupIDLayerTuple,EventGroupLayerResult>();
        
        public EventGroupLayerResultCollection() : base() { }
        /// <summary>Will return the result for the specified eventGroupID/Layer
        /// combination, or create a new result and return it.</summary>
        public EventGroupLayerResult this[Int32 eventGroupID, Layer layer]
        {
            get
            {
                EventGroupLayerResult retval;
                if( !_Index.TryGetValue(new EventGroupIDLayerTuple(eventGroupID, layer), out retval) )
                {
                    retval = new EventGroupLayerResult() { EventGroupID = eventGroupID, Layer = layer };
                    this.Add(retval);
                }
                return retval;
            }
        }
        public bool Contains(Int32 eventGroupID, Layer layer)
        {
            return _Index.ContainsKey(new EventGroupIDLayerTuple(eventGroupID, layer));
        }
        #region Index Maintenance
        protected override void ClearItems()
        {
            _Index.Clear();
            base.ClearItems();
        }
        protected override void InsertItem(int index, EventGroupLayerResult item)
        {
            _Index.Add(new EventGroupIDLayerTuple(item.EventGroupID, item.Layer), item);
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            _Index.Remove(new EventGroupIDLayerTuple(this[index].EventGroupID, this[index].Layer));
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, EventGroupLayerResult item)
        {
            _Index.Remove(new EventGroupIDLayerTuple(this[index].EventGroupID, this[index].Layer));
            _Index.Add(new EventGroupIDLayerTuple(item.EventGroupID, item.Layer), item);
            base.SetItem(index, item);
        }
        #endregion
    }
