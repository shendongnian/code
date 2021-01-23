            var dyn = GetDynamicObject(new Dictionary<string, object>()
            {
                {"prop1", 12},
            });
            Console.WriteLine(dyn.prop1);
            dyn.prop1 = 150;
