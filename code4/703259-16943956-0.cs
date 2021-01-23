    public class MyDict : Dictionary<string, A> {
        public MyDict() {
            // Perform the default initialization here
            ...
        }
        public MyDict(IDictionary<string,A> dict) {
            // Initialize with data from the dict
            ...
        }
    }
    ...
    public MyDict GetSubSet(int testVal) {
        var ret = dict.Where(e => e.Value.aValue == testVal).
                       ToDictionary(k => k.Key, k => k.Value);
        return new MyDict(ret);
    }
 
