    var arr1 = new int[] { 1, 202, 4, 55 };
    var arr2 = new int[] { 40, 7 };
    var arr3 = new int[] { 2, 48, 5 };
    var arr4 = new int[] { 40, 8, 90 };
    var max = new int[][] { arr1, arr2, arr3, arr4 }
               .Select(arr => new { 
                       IArray = arr, 
                       SArray = String.Join("",arr.Select(i => i.ToString("X8"))) 
               })
               .OrderByDescending(x => x.SArray)
               .First()
               .IArray;
