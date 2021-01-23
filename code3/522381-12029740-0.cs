    public class RowStyleSelector : StyleSelector
    {
        public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            var i = (item as Item);
            if (i.I == 0) return (Style)App.Current.Resources["Selected"];
            else return (Style)App.Current.Resources["Normal"];
        }
    }
