        /// <summary>
        /// Return all selected persons from the Grid
        /// </summary>
        public IList<Person> GetItems()
        {
            var ret = new List<Person>();
            Array.ForEach
                (
                    gridView1.GetSelectedRows(), 
                    cell => ret.Add(gridView1.GetRow(cell) as Person)
                );
            return ret;
        }
