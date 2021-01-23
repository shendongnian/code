    int[] numbers = new int[] { 1, 2, 3, 5 };
    List<double> m = new List<double>();
    m.Add(1);
    m.Add(1.5);
    m.Add(2.6);
    m.Add(4);
    m.Add(50);
    
    foreach (int n in numbers)
    {
        for (int i = 0; i < m.Count; i++)
        {
            try
            {
                if (m[i] <= n && m[i + 1] >= n)
                    MessageBox.Show(
                        string.Format("{0} is between {1} and {2}",
                        n, m[i], m[i + 1]));
            }
            catch (Exception){ }
        }
    }
