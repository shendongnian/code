    public return List<Tuple<double, double>> uniquePairs(List<double[]> lst)
    {
    HashSet<Tuple<double, double>> hash = new HashSet<Tuple<double, double>>();
    for (int i = 0; i < lst.count; i++)
    {
    hash.Add(new Tuple<double, double>(lst[i][0], lst[i][1]))
    }
    List<Tuple<double, double>> lstt = hash.Distinct().ToList();
    }
    
    For example:
    List<double[]> lst = new List<double[]> {new double[] { 1, 2 }, new double[] { 2, 3 }, new double[] { 3, 4 }, new double[] { 1, 4 }, new double[] { 3, 4 }, new double[] { 2, 1 }}; //  this list has 4 unique numbers, 5 unique pairs, the desired output would be the 5 unique pairs (count = 5)
    List<Tuple<double, double>> lstt = uniquePairs(lst);
    Console.WriteLine(lstt.Count().ToString());
