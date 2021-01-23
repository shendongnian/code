            IEnumerable<object> items = new Object[]{ "first", "second", "third", "next", "and so on" };
            IEnumerable<object> col1Items = new List<object>(),
                                col2Items = new List<object>(), 
                                col3Items = new List<object>();
            Object[] list = new Object[]{col1Items, col2Items, col3Items};
            int col = 0;
            for (int i = 0; i < items.Count(); i++, col++)
            {
                if (col == 3) col = 0;
                ((IList<object>)(list[col])).Add( items.ElementAt(i));
                
            }
