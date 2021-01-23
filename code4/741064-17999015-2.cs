           IEnumerable<object> items = new Object[]{ "first", "second", "third", "next", "and so on", "and on" };
            int numItems = items.Count();
            IEnumerable<object> col1Items = new List<object>(),
                                col2Items = new List<object>(), 
                                col3Items = new List<object>();
            Object[] list = new Object[]{col1Items, col2Items, col3Items};
            int limit = items.Count()/3;
            if (items.Count() == 3) limit = 1;
            for (int i = 0; i < items.Count(); i++ )
            {
                int col = i / limit;
                if (limit == 1) col = i%3;
                ((IList<object>)(list[col])).Add( items.ElementAt(i));
                
            }
