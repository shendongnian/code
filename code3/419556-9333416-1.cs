      Person p = new Person();
        p.ID=2;
        p.Name="Z";
        pList.Add(p);
        Person p1 = new Person();
        // Change properties of p1, not p!
        p1.ID = 1;
        p1.Name = "A";
        pList.Add(p1);
