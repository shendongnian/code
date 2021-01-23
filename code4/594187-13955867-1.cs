    public class MoneyLabelProvider : GenericLabelProvider<int>
    {
        public override System.Windows.UIElement[] CreateLabels(Microsoft.Research.DynamicDataDisplay.Charts.ITicksInfo<int> ticksInfo)
        {
            var customElements = new UIElement[ticksInfo.Ticks.Length];
            for (int i = 0; i < customElements.Length; i++)
            {
                var mv = new MoneyView(); // View provides the money style format
                var money = new Money(0, 0, ticksInfo.Ticks[i]); // Data class provides the calculation
                mv.DataContext = money; // Bind the data to the view
                customElements[i] = mv;
            }
            return customElements;
        }
    }
