    public partial class SupplierView
    {
        public List<string> MaterialTypeList
        {
            get { return (List<string>)GetValue(MaterialTypeListProperty); }
            set { SetValue(MaterialTypeListProperty, value);}
        }
    
        public static readonly DependencyProperty MaterialTypeListProperty =
                DependencyProperty.Register("MaterialTypeList", typeof(string), typeof(SupplierView),
                new PropertyMetadata(null));
    }
