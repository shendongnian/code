    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            Color color = Color.FromArgb(255, 0, 0);
            Console.WriteLine(color.Name); // ffff0000
            
            var colorLookup = typeof(Color)
                   .GetProperties(BindingFlags.Public | BindingFlags.Static)
                   .Select(f => (Color) f.GetValue(null, null))
                   .Where(c => c.IsNamedColor)
                   .ToLookup(c => c.ToArgb());
            // There are some colours with multiple entries...
            foreach (var namedColor in colorLookup[color.ToArgb()])
            {
                Console.WriteLine(namedColor.Name);
            }
        }
    }
