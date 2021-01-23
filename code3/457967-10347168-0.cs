        public BindingListCollectionView View1 { get; set; }
        //ctor, create View with initial filter
        View1 = new BindingListCollectionView(new DataView(Dt) { RowFilter = "Name like 'R%'" })
        //dynamic filter on runtime
        View1.CustomFilter = "ABCDEFG (<-- Random Columnname) Like '" + textBox.Text+"'";
     
