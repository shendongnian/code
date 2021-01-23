    // before class declaration
    using System.Collections.Generic;
    // replaces myQueue declaration
    static Queue<int> myQueue = new Queue<int>();
    // later, in pop - myQueue already returns ints, so no casting needed
    return myQueue.Dequeue();
