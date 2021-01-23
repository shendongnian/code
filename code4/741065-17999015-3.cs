            IEnumerable<object> items = new Object[]{ "1", "2", "3", "4", "5", "6", "7","8", "9", "10", "11", "12","13", "14" };
            IEnumerable<object> col1Items = new List<object>(),
                                col2Items = new List<object>(), 
                                col3Items = new List<object>();
            Object[] list = new Object[]{col1Items, col2Items, col3Items};
            int limit = items.Count()/3;
            int len = items.Count();
            int col;            
            for (int i = 0; i < items.Count(); i++ )
            {                
                if (len == 3) col = i;
                else col = i / limit;
                if (col >= 3) col = i%limit ;
                ((IList<object>)(list[col])).Add( items.ElementAt(i));
                
            }
