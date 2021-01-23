            List<double[]> DataList = new List<double[]>();
            private void button1_Click(object sender, EventArgs e)
            {
                DataList.Add(new double[] { 2, 3, 5, 6, 8 });
                DataList.Add(new double[] { 2, 3, 5, 6, 9 });
                DataList.Add(new double[] { 2, 3, 5, 6, 5 });
                DataList.Add(new double[] { 2, 3, 5, 6, 12 });
                DataList.Sort(new DoubleArrayComparer());
                DataList.Reverse();
            }
            class DoubleArrayComparer : IComparer<double[]>
            {
                public int Compare(double[] x, double[] y)
                {
                    if(x.Length>0 && y.Length>0)
                    {
                        if(x[x.Length-1] > y[y.Length-1])
                            return 1;
                        else if(x[x.Length-1] < y[y.Length-1])
                            return -1;
                        else
                            return 0;
    
                    }
                    else if(x.Length == 0 && y.Length!=0)
                        return -1;
                    else if(y.Length == 0 && x.Length!=0)
                        return 1;
                    else
                        return 0;
                }
            }
