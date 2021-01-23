    using System.Linq;
    using System.Collections.Generic;
    
    var assem = Assembly.GetExecutingAssembly();
    var fs = assem.GetManifestResourceStream("res.resources");
    var rr = new ResourceReader(fs);
    
    Dictionary<string, object> data = rr
                    .OfType<DictionaryEntry>()
                    .Select(i => new { Key = i.Key.ToString(), value = i.Value })
                    .ToDictionary(i => i.Key, i => i.value);
    
    // Getting all resource names
    IEnumerable<string> names = data.Keys;
    // Getting all values
    IEnumerable<object> values = data.Values;
