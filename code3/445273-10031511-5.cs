        private void ListPreferredPartitons(int n, ListBox listOut)
        {
            IList<List<int>> pts = Partitions.EnumerateAll(n);
            pts = Partitions.ReOrderPartitions(pts);
            listOut.Items.Clear();
            foreach (List<int> prt in pts)
            {
                // reverse the list, so that the largest integers will now be first.
                prt.Reverse();
                string lin = "";
                foreach (int k in prt)
                {
                    if (lin.Length > 0) lin += ", ";
                    lin += k.ToString();
                }
                listOut.Items.Add(lin);
            }
        }
