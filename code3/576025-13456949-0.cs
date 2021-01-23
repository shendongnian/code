       List<int> ranges = new List<int>() {100, 1000, 1000000};
       List<int> sizes = new List<int>(new int[]{99,98,10,5,5454, 12432, 11, 12432, 992,    56, 222});
       void Main()
       {
        	var xx = sizes.GroupBy (size => GetRangeValue(size));
	
	        xx.Dump();
        }
       private int GetRangeValue(int size)
       {
            // find the first value in ranges which is bigger than or equal to our size
	        return ranges.First(range => range >= size);
        }
   
