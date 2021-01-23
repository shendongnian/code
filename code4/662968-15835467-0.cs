    public class Holder {
        public long Value { get; set; }
    }
    public void Increment(Dictionary<string, Holder> dict, string key, int increment) {
            Holder box;
            if(dict.TryGetValue(key, out box)) box.Value += increment;
            else {
                dict[key] = new Holder {
                    Value = increment
                };
            }
        }
