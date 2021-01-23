            CustomClassCollection a = new CustomClassCollection();
            CustomClassCollection b = ObjectCopier.Clone<CustomClassCollection>(a);
            a.Add(new CustomClass(1, "A"));
            a.Add(new CustomClass(2, "B"));
            a.Add(new CustomClass(3, "C"));
            b.Add(new CustomClass(1, "A"));
            b.Add(new CustomClass(2, "B"));
