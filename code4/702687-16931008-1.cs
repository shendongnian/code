            List<DataTable> dataTables = new List<DataTable>();
            List<string> c = new List<string>();
            c.Add("A");
            c.Add("B");
            c.Add("C");
            dataTables.Add(ss(c));
            List<string> c2 = new List<string>();//New List
            c2.Add("B");
            c2.Add("C");
            dataTables.Add(ss(c2));
            List<string> c3 = new List<string>();//New List
            c3.Add("A");
            c3.Add("B");
            dataTables.Add(ss(c3));
            var setsOfIds = dataTables.Select(t => t.AsEnumerable().Select(x => x.Field<string>("ELIGIBLE")).OfType<string>());                        
            var commonIds = IntersectAll<string>(setsOfIds);
