            MyList<string> a = new MyList<string>("a");
            MyList<string> b = new MyList<string>("b");
            a.Add("normal add to list a");
            MyList<string>.AddToListByName("hello add to a", "a");
            MyList<string>.AddToListByName("hello add to b", "b");
