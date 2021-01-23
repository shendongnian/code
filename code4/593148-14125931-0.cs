    public static IEnumerable<MyObject> GetChanges(
        IEnumerable<MyObject> from, IEnumerable<MyObject> to)
    {
        var dict = to.ToDictionary(mo => new { mo.Key, mo.Day });
        // Check that keys are distinct in from, too:
        var throwaway = from.ToDictionary(mo => new { mo.Key, mo.Day });
        // Adjustments of items found in "from"
        foreach (MyObject mo in from)
        {
            var key = new { mo.Key, mo.Day };
            MyObject newVal;
            if (dict.TryGetValue(key, out newVal))
            {
                // Return item indicating adjustment
                yield return new MyObject { 
                    Key = mo.Key, Day = mo.Day, Value = newVal.Value - mo.Value };
                dict.Remove(key);
            }
            else
            {
                // Return item indicating removal
                yield return new MyObject {
                    Key = mo.Key, Day = mo.Day, Value = -mo.Value };
            }
        }
        // Creation of new items found in "to"
        foreach (MyObject mo in dict.Values)
        {
            // Return item indicating addition
            // (Clone as all our other yields are new objects)
            yield return new MyObject {
                Key = mo.Key, Day = mo.Day, Value = mo.Value };
        }
    }
