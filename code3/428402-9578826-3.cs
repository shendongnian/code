     static readonly string[] map = new string[] {
        "14", "18", ...
     };
     int index = Int32.Parse(pk.Substring(2, 2)); // Error handling elided.
     
     if (index < 0 || index > map.Length)
     {
         // Handle error, like in the "default:" case of the switch statement
     }
     else
     {
         ViewBag.Type = _reference.Get(map[index], model.Type).Value;
     }
