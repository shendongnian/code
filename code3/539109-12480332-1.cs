            Type type = typeof(Fields); // MyClass is static class with static properties
            foreach (var p in type.GetFields( System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic))
            {
                var v = p.GetValue(null); // static classes cannot be instanced, so use null...
                //do something with v
                Console.WriteLine(v.ToString());
            }
