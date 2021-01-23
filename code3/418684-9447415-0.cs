            var list = new List<string>();
            list.Add("Foo");
            list.Add("Bar");
            list.ForEach((item) => 
            { 
                if(item=="Foo") 
                    list.Remove(item); 
            });
