    int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
    int splitIndex = 4; // or (a.Length / 2) to split in the middle.
    
    var list1 = a.Take(splitIndex).ToArray(); // Returns a specified number of contiguous elements from the start of a sequence.
    var list2 = a.Skip(splitIndex).ToArray(); // Bypasses a specified number of elements in a sequence and then returns the remaining elements.
    
