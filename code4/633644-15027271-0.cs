    LinkedList<string> linkedList = new LinkedList<string>();
    int32 size3 = linkedList.Count; // From ICollection
    int32 size2 = linkedList.Count(); // From IEnumerable
    int64 bigSize = linkedList.LongCount(); // From IEnumerable
    
    int32 size4 = linkedList.Count(s => s == "a"); // Count only strings equals "a"
