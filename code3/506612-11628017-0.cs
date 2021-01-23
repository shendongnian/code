    [Test]
        public void StringSplit()
        {
            var splits = AllPossibleSplits("hello".Select(c => c.ToString()).ToList());
            Assert.AreEqual(16, splits.Count);
            Assert.AreEqual("hello", splits.First().First());
            Assert.AreEqual("hello".Length, splits.Last().Count());
        }
        private List<List<string>> AllPossibleSplits(List<string> source)
        {
            
            if (source.Count == 0)
            {
                return new List<List<string>>();
            }
            if (source.Count == 1)
            {
                return new List<List<string>> { source };
            }
            var firstTwoJoined = new List<string> { source[0] + source[1] };
            firstTwoJoined.AddRange(source.Skip(2));
            var justFirst = new List<string> { source[0] };
            var withoutFirst = AllPossibleSplits(source.Skip(1).ToList());
            var result = new List<List<string>>();
            result.AddRange(AllPossibleSplits(firstTwoJoined));
            result.AddRange(withoutFirst.Select(list => justFirst.Concat(list).ToList()));
            return result;
        }
