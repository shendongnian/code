    void SomeMethod(){
          var arr = new Object1[]{
                new Object1{Name="n1",ID=1},
                new Object1{Name="n2",ID=2},
                new Object1{Name="n3",ID=3},
                new Object1{Name="n4",ID=4}
            };
            var arr2 = new Object2[]{
                new Object2{Name="o1", Ref=1},
                new Object2{Name="o2", Ref=2},
                new Object2{Name="o3", Ref=1},
                new Object2{Name="o4", Ref=2},
                new Object2{Name="o5", Ref=5},
                new Object2{Name="o6", Ref=3},
                new Object2{Name="o7", Ref=5}
            };
            List<Object1> listObject1 = arr.Where(p => p.ID == 1 || p.ID == 2).ToList();
            List<Object2> listObject2 = arr2.Where(p =>listObject1.Any(q => p.Ref == q.ID)).ToList();
    }
        class Object1
        {
            public string Name;
            public int ID;
        }
        class Object2
        {
            public string Name;
            public int Ref;
        }
    
