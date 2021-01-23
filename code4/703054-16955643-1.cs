        private static void TestCastWithGenerics()
        {
            BaseDef bd = new BaseDef()
            {
                Id = 1
            };
            DerivedView dv = new DerivedView()
            {
                Id = 1,
                Name = "DV",
            };
            var aClassD = new SomeHelper<DerivedDef, DerivedView>();
            aClassD.ConvertToDef = dv1 => dv1; // Behind scenes the implicit cast is being invoked...
            DerivedDef dd = aClassD.Convert(dv);
            var aClassB = new SomeHelper<BaseDef, BaseView>();
            aClassB.ConvertToView = bd1 => bd1; // Behind scenes the implicit cast is being invoked...
            BaseView bv = aClassB.Convert(bd);
            Console.WriteLine(dd);
            Console.WriteLine(bv);
        }
