    void Caller()
    {
        // think of ss as a piece of paper that tells you where to find the list.
        List<string> ss = new List<string> { "a", "b" };
        //passing by value: we take another piece of paper and copy the information on ss to that piece of paper; we pass that to the method
        DoNotReassign(ss);
        //as this point, ss refers to the same list, that now contains { "a", "b", "c" }
        //passing by reference: we pass the actual original piece of paper to the method.
        Reassign(ref ss);
        // now, ss refers to a different list, whose contents are { "x", "y", "z" }
    }
    void DoNotReassign(List<string> strings)
    {
        strings.Add("c");
        strings = new List<string> { "x", "y", "z" }; // the caller will not see the change of reference
        //in the piece of paper analogy, we have erased the piece of paper and written the location
        //of the new list on it.  Because this piece of paper is a copy of SS, the caller doesn't see the change.
    }
    void Reassign(ref List<string> strings)
    {
        strings.Add("d");
        //at this point, strings contains { "a", "b", "c", "d" }, but we're about to throw that away:
        strings = new List<string> { "x", "y", "z" };
        //because strings is a reference to the caller's variable ss, the caller sees the reassignment to a new collection
        //in the piece of paper analogy, when we erase the paper and put the new object's
        //location on it, the caller sees that, because we are operating on the same
        //piece of paper ("ss") as the caller 
    }
