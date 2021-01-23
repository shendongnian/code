    public class RowStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            System.Data.DataRow targetItem = item as System.Data.DataRow;
            if (targetItem != null)
            {
                // You can work with your data here.
                if ((int)targetItem["IDColumn"] == 0)
                {
                    // Locate and return the style for when ID = 0.
                    return (Style)Application.Current.FindResource("ResourceName");
                }
                else
                    return base.SelectStyle(item, container);
            }
            else
                return base.SelectStyle(item, container);            
        }
    }
