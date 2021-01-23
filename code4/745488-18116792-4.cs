    public void DoWork2(List<int[]> c_Top)
        {
            var distinctZvalues = c_Top.Select(p => p[2]); // this gets an enumerable object of unique Z values
            Dictionary<int, List<int[]>> xy_minus = new Dictionary<int, List<int[]>>();
            Dictionary<int, List<int[]>> xy_plus = new Dictionary<int, List<int[]>>();
            foreach (var z in distinctZvalues)
            {
                List<int[]> minus = new List<int[]>();
                List<int[]> plus = new List<int[]>();
                List<int[]> coords = c_Top.Where(p => p[2] == z).ToList(); // pull all int[] from c_Top where z == z
                foreach (int[] coord in coords)
                    if (coord[0] > coord[1])
                        minus.Add(coord);
                    else
                        plus.Add(coord);
                xy_minus.Add(z, minus);
                xy_plus.Add(z, plus);
            }
        }
