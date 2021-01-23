     static readonly Dictionary<string, string> map = new Dictionary<string, string> {
         { "00", "14" },
         { "01", "18" },
         // ... more ...
     };
     // ... in your method ...
     string str = pk.Substring(2, 2);
     string val;
     if (!map.TryGetValue(str, out val))
     {
         // Handle error, like in the "default:" case of the switch statement
     }
     else
     {
         ViewBag.Type = _reference.Get(val, model.Type).Value;
     }
