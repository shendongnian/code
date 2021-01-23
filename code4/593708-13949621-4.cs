    public class GenerateFromFixedSequence<T> : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var items = CreateFixedSequence(fixture);
            fixture.Register(() => GetRandomElementInSequence(items));
        }
    
        private static IEnumerable<T> CreateFixedSequence(IFixture fixture)
        {
            return fixture.CreateAnonymous<T[]>();
        }
    
        private static T GetRandomElementInSequence(IEnumerable<T> items)
        {
            var randomIndex = new Random().Next(0, --items.Count());
            return items.ElementAt(randomIndex);
        }
    }
