    List<Grades> ranges = new List <Grades>();
    var strGrades = "40-50, 55-62, 65-72, 80-82, 85-92, 95-99, 110-115";
    var splitGrades = strGrades.Split(char.Parse(","));
    foreach(var item in splitGrades)
    {
        var splitAgain = items.Split(char.Parse("-"));
        int myMax = Math.Max(int.Parse(splitAgain[0]), int.Parse(splitAgain[1]));
        int myMin = Math.Min(int.Parse(splitAgain[0]), int.Parse(splitAgain[1]));
        //my enumerable list   
        var erange = Enumerable.Range(myMax, myMax - myMin + 1).ToList()
        foreach (var maxrange in erange)
        {
           for (int q = myMin; q < maxrange; q++)
            {
             //custom extension method for Between
             if (!q.Between((myMin), (myMax), true))
             {
              //Public class Grades{public int Start, get; set }                  
                ranges.Add(new Grades()
                {
                  Start= q,
                });
             }
           }
         }        
      }
     return ranges;
    }
