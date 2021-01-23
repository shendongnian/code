    usign System.Linq;
    var map = File.ReadAllLines()
                  .Select(l =>
                   {
                        var pair = l.Split(',');
                        return new { First = pair[0], Second = pair[1] }
                   })
                  .ToDictionary(k => k.First, v => v.Second);
