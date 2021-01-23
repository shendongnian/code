    List<string> list = ...;
    var iterator = WrappingIterator<string>.CreateAt(list, "B");
    Console.WriteLine(iterator.GetNext());  // Prints C
    Console.WriteLine(iterator.GetNext());  // Prints A
    Console.WriteLine(iterator.GetNext());  // Prints B
