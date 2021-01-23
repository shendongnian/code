    void Main()
    {
	var lists = new [] {new[] {1, 1, 2, 3, 4, 5, 6, 9, 11, 13},
						new[] {1, 1, 5, 6, 7, 13},
						new[] {1, 1, 6, 8, 9, 13},
						};
	
	var mergedSet = lists[0];
	for(var i = 1; i < lists.Length; i++)
	{
		mergedSet = Merge(lists[i], mergedSet);
	}
    }
    int[] Merge (int[] sla, int[] slb)
    {
	int ixa = 0, ixb = 0;
	List<int> result = new List<int>();
	while(ixa < sla.Length && ixb < slb.Length)
	{
		if (sla[ixa] < slb[ixb]) { ixa++; } 
		else if (sla[ixa] > slb[ixb]) { ixb++; } 
		else { result.Add(sla[ixa]); ixa++; ixb++; }
	}
	return result.ToArray();
    }    
