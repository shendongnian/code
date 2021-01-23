        public class MyRibbonGroup : RibbonGroup
        {
        public MyRibbonGroup() 
            : base()
        {
        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            // Force the bindings to be restored after 
            // the ribbon group collapsed or expanded to a menu button.
            if (e.Property == RibbonGroup.IsCollapsedProperty)
            {
                object objDataContext = this.DataContext;
                this.DataContext = null;
                this.DataContext = objDataContext;
            }
        }
    }
