        public static List<List<int>> EnumerateAll(int n)
        {
            /* Fastest known algorithim for enumerating partitons
             * (not counting the re-ordering that I added)
             * Based on the Python code from http://homepages.ed.ac.uk/jkellehe/partitions.php
             */
            List<List<int>> lst = new List<List<int>>();
            int[] aa = new int[n + 1];
            List<int> a = new List<int>(aa.ToList<int>());
            List<int> tmp;
            int k = 1;
            a[0] = 0;
            int y = n - 1;
            
            while (k != 0)
            {
                int x = a[k - 1] + 1;
                k -= 1;
                while (2 * x <= y)
                {
                    a[k] = x;
                    y -= x;
                    k += 1;
                }
                int l = k + 1;
                while (x <= y)
                {
                    a[k] = x;
                    a[l] = y;
                    // copy just the part that we want
                    tmp = (new List<int>(a.GetRange(0, k + 2)));
                    
                    // insert at the beginning to return partions in the expected order
                    lst.Insert(0, tmp);
                    x += 1;
                    y -= 1;
                }
                a[k] = x + y;
                y = x + y - 1;
                
                // copy just the part that we want
                tmp = (new List<int>(a.GetRange(0, k + 1)));
                // insert at the beginning to return partions in the expected order
                lst.Insert(0, tmp);
            }
            return lst;
        }
