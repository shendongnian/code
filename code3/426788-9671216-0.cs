    public class SingleObjectView : CompositeDataBoundControl
        {
            private object dataSource;
            public override object DataSource
            {
                get { return new List<object> { dataSource }; }
                set { dataSource = value; }
            }
    
    
            protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
            {
                SingleItem singleItem = null;
                if (dataBinding)
                {
                    var it = dataSource.GetEnumerator();
                    it.MoveNext();
    
                    singleItem = new SingleItem(it.Current);
                }
                else
                {
                    singleItem = new SingleItem(null);
                }
    
                ItemTemplate.InstantiateIn(singleItem);
                Controls.Add(singleItem);
                if (dataBinding)
                    singleItem.DataBind();
                return 1;
            }
    
    
            [PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(SingleItem))]
            public ITemplate ItemTemplate { get; set; }
        }
    
        public class SingleItem : Control, IDataItemContainer
        {
            public SingleItem(object dataItem)
            {
                DataItem = dataItem;
            }
            public object DataItem { get; set; }
    
            public int DataItemIndex
            {
                get { return 0; }
            }
    
            public int DisplayIndex
            {
                get { return 0; }
            }
        }
