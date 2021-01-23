public class Range {
	public DateTime Start { get; set; }
	public DateTime Stop { get; set; }
	public int Parent { get; set; }
	
	public Range(DateTime start, DateTime stop)
	{
		Start = start;
		Stop = stop;
	}
}
void Main()
{
	List<Range> ranges = new List<Range>();
	ranges.Add(new Range(new DateTime(2019, 10, 1), new DateTime(2019, 10, 2)));
	ranges.Add(new Range(new DateTime(2019, 10, 2), new DateTime(2019, 10, 3)));
	ranges.Add(new Range(new DateTime(2019, 10, 1), new DateTime(2019, 10, 3)));
	ranges.Add(new Range(new DateTime(2019, 10, 4), new DateTime(2019, 10, 5)));
	ranges.Add(new Range(new DateTime(2019, 10, 6), new DateTime(2019, 10, 8)));
	ranges.Add(new Range(new DateTime(2019, 10, 5), new DateTime(2019, 10, 7)));
	ranges.Add(new Range(new DateTime(2019, 10, 9), new DateTime(2019, 10, 9)));
	var set = new DisjointSet(ranges.Count());
	var IsOverlaping = new Func<Range, Range, bool>((a, b) => a.Start < b.Stop && b.Start < a.Stop	);
	for (var i = 0; i < ranges.Count; i++)
	{
		for (var j = 0; j < ranges.Count; j++)
		{
			if (IsOverlaping(ranges[i], ranges[j]))
			{
				set.Union(i,j);
			}
		}
	}
	for (int i = 0; i < set.Count; i++)
	{
		ranges[i].Parent = set.Parent[i];
	}
	ranges.GroupBy(x=> x.Parent);
}
/// <summary>
/// A Union-Find/Disjoint-Set data structure.
/// </summary>
public class DisjointSet {
    /// <summary>
    /// The number of elements in the universe.
    /// </summary>
    public int Count { get; private set; }
    /// <summary>
    /// The parent of each element in the universe.
    /// </summary>
    public int[] Parent;
    /// <summary>
    /// The rank of each element in the universe.
    /// </summary>
    private int[] Rank;
    /// <summary>
    /// The size of each set.
    /// </summary>
    private int[] SizeOfSet;
    /// <summary>
    /// The number of disjoint sets.
    /// </summary>
    public int SetCount { get; private set; }
    /// <summary>
    /// Initializes a new Disjoint-Set data structure, with the specified amount of elements in the universe.
    /// </summary>
    /// <param name='count'>
    /// The number of elements in the universe.
    /// </param>
    public DisjointSet(int count) {
        this.Count = count;
        this.SetCount = count;
        this.Parent = new int[this.Count];
        this.Rank = new int[this.Count];
        this.SizeOfSet = new int[this.Count];
        for (int i = 0; i < this.Count; i++) {
            this.Parent[i] = i;
            this.Rank[i] = 0;
            this.SizeOfSet[i] = 1;
        }
    }
    /// <summary>
    /// Find the parent of the specified element.
    /// </summary>
    /// <param name='i'>
    /// The specified element.
    /// </param>
    /// <remarks>
    /// All elements with the same parent are in the same set.
    /// </remarks>
    public int Find(int i) {
        if (this.Parent[i] == i) {
            return i;
        } else {
            // Recursively find the real parent of i, and then cache it for later lookups.
            this.Parent[i] = this.Find(this.Parent[i]);
            return this.Parent[i];
        }
    }
	/// <summary>
	/// Unite the sets that the specified elements belong to.
	/// </summary>
	/// <param name='i'>
	/// The first element.
	/// </param>
	/// <param name='j'>
	/// The second element.
	/// </param>
	public void Union(int i, int j)
	{
		// Find the representatives (or the root nodes) for the set that includes i
		int irep = this.Find(i),
			// And do the same for the set that includes j
			jrep = this.Find(j),
			// Get the rank of i's tree
			irank = this.Rank[irep],
			// Get the rank of j's tree
			jrank = this.Rank[jrep];
		// Elements are in the same set, no need to unite anything.
		if (irep == jrep)
			return;
		this.SetCount--;
		// If i's rank is less than j's rank
		if (irank < jrank)
		{
			// Then move i under j
			this.Parent[irep] = jrep;
			this.SizeOfSet[jrep] += this.SizeOfSet[irep];
		} // Else if j's rank is less than i's rank
		else if (jrank < irank)
		{
			// Then move j under i
			this.Parent[jrep] = irep;
			this.SizeOfSet[irep] += this.SizeOfSet[jrep];
		} // Else if their ranks are the same
		else
		{
			// Then move i under j (doesn't matter which one goes where)
			this.Parent[irep] = jrep;
			this.SizeOfSet[jrep] += this.SizeOfSet[irep];
			// And increment the the result tree's rank by 1
			this.Rank[jrep]++;
		}
	}
	/// <summary>
	/// Return the element count of the set that the specified elements belong to.
	/// </summary>
	/// <param name='i'>
	/// The element.
	/// </param>
	public int SetSize(int i)
	{
		return this.SizeOfSet[this.Find(i)];
	}
}
Result:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/uxl88.png
