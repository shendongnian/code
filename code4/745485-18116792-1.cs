        public void DoWork(List<int[]> c_Top)
        {
            var distinctZvalues = c_Top.Select(p => p[2]); // this gets an enumerable object of unique Z values
            List<int[]> xy_minus = new List<int[]>();
            List<int[]> xy_plus = new List<int[]>();
            foreach (var z in distinctZvalues)
            {
                List<int[]> coords = c_Top.Where(p => p[2] == z).ToList(); // pull all int[] from c_Top where z == z
                foreach (int[] coord in coords)
                    if (coord[0] > coord[1])
                        xy_minus.Add(coord);
                    else
                        xy_plus.Add(coord);
            }
        }
