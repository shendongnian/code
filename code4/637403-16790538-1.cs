    using FluentAssertions;
    using System.Linq;
    using Xunit;
    public class MultiLookupSpec
    {
        MultiLookup<int, string> Fixture = new MultiLookup<int,string>();
        [Fact]
        public void NewLookupShouldBeEmpty()
        {
            Fixture.Count.Should().Be(0);
        }
        [Fact]
        public void AddingANewValueToANonExistentKeyShouldCreateKeyAndAddValue()
        {
            Fixture.Add(0, "hello");
            Fixture.Count.Should().Be(1);
        }
        [Fact]
        public void AddingMultipleValuesToAKeyShouldGenerateMultipleValues()
        {
            Fixture.Add(0, "hello");
            Fixture.Add(0, "cat");
            Fixture.Add(0, "dog");
            Fixture[0].Should().BeEquivalentTo(new []{"hello", "cat", "dog"});
        }
        [Fact]
        public void RemovingAllElementsOfKeyWillAlsoRemoveKey()
        {
            Fixture.Add(0, "hello");
            Fixture.Add(0, "cat");
            Fixture.Add(0, "dog");
            Fixture.Remove(0, "dog");            
            Fixture.Remove(0, "cat");            
            Fixture.Remove(0, "hello");
            Fixture.Contains(0).Should().Be(false);
        }
        [Fact]
        public void EnumerationShouldWork()
        {
            Fixture.Add(0, "hello");
            Fixture.Add(0, "cat");
            Fixture.Add(0, "dog");
            Fixture.Add(1, "house");
            Fixture.Add(2, "pool");
            Fixture.Add(2, "office");
            Fixture.Select(s => s.Key).Should().Contain(new[] { 0, 1, 2 });
            Fixture.SelectMany(s => s).Should().Contain(new[] { "hello", "cat", "dog", "house", "pool", "office" });
        }
    }
