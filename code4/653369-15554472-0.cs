            List<dynamic> mylist = new List<dynamic>();
            dynamic data = new ExpandoObject();
            data.Foo = "foo";
            data.ID = 1;
            mylist.Add(data);
            data = new ExpandoObject();
            data.Foo = "foobar";
            data.ID = 2;
            mylist.Add(data);
            data = new ExpandoObject();
            data.Foo = "foobar2";
            data.ID = 2;
            mylist.Add(data);
            data = new ExpandoObject();
            data.Foo = "foobar2";
            data.ID = 3;
            mylist.Add(data);
            int idiminterestedin = 2;
            var dynamicselected = mylist.Select(d=>((IDictionary<string,object>)d)).Where(d=>
            {
                object id;
                if (d.TryGetValue("ID",out id))
                {
                    return (id is int) && (int)id == idiminterestedin;
                }
                return false;
            });
            foreach (var v in dynamicselected)
            {
                Console.WriteLine(v["Foo"]);
            }
            Console.ReadLine();
