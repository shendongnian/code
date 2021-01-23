    public class Something {
        private ImmutableDictionary<string, string> dict = ImmutableDictionary<string, string>.Empty;
        public void Add(string key, string value) {
           ApplyChangeOptimistically(
              ref this.dict,
              d => d.ContainsKey(key) ? d : d.Add(key, value));
        }
    }
