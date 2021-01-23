    public class GenerateLineItemFromFixedSequence : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var items = CreateFixedLineItemSequence(fixture);
            fixture.Register(() => GetRandomElementInSequence(items));
        }
    
        private static IEnumerable<LineItem> CreateFixedLineItemSequence(IFixture fixture)
        {
            return fixture.CreateAnonymous<LineItem[]>();
        }
    
        private static LineItem GetRandomElementInSequence(IEnumerable<LineItem> items)
        {
            var randomIndex = new Random().Next(0, --items.Count());
            return items.ElementAt(randomIndex);
        }
    }
