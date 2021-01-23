    public class VariableSizedGridView : GridView
    {
        protected override void PrepareContainerForItemOverride(Windows.UI.Xaml.DependencyObject element, object item)
        {
            try
            {
                dynamic gridItem = item;
                var typeItem = item as CommonType;
                if (typeItem != null)
                {
                    var heightPecentage = (300.0 / typeItem.WbmImage.PixelHeight);
                    var itemWidth = typeItem.WbmImage.PixelWidth * heightPecentage;
                    var columnSpan = Convert.ToInt32(itemWidth / 10.0);
                    if (gridItem != null)
                    {
                        element.SetValue(VariableSizedWrapGrid.ItemWidthProperty, itemWidth);
                        element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, columnSpan);
                        element.SetValue(VariableSizedWrapGrid.RowSpanProperty, 1);
                    }
                }
            }
            catch
            {
                element.SetValue(VariableSizedWrapGrid.ItemWidthProperty, 100);
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, 1);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, 1);
            }
            finally
            {
                base.PrepareContainerForItemOverride(element, item);
            }
        }
