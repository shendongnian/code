    var tempList = new List<Int32>(){
        1,2,3,2,2,2,3,3,4,5,6,7,7,7,8,9
    };
    IEnumerable<int> result = tempList
     .GroupBy(i => i)
     .Where(g => g.Count() == 3)
     .Select(g => g.Key); 
    Console.WriteLine(string.Join(",",result));
