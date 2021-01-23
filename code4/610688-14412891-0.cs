    public abstract class IReadOnlyCollectionTests<T>
    {
        protected abstract IReadOnlyCollection<T> CreateInstance(params T[] data);
        protected abstract T[] GetData();
        [Test]
        public void Contains_GivenExistingValue_ReturnsTrue()
        {
            // Given
            T[] data = GetData();
            T value = data[1];
            var sut = CreateInstance(data);
            
            ...
        }
    }
    [TestFixture]
    public class BitArrayROC : IReadOnlyCollectionTests<bool>
    {
        protected override bool[] GetData()
        {
            return new[] { true, false };
        }
        ...
    }
