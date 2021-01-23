    delegate (string x, string y) {
        if (x == y)   // NOT A GOOD IDEA - 
                      // THE Sort method should not call a string with itself,
                      // and if this is doing string comparison
                      // (I'm rusty on C#), you're
                      // wasting a comparison if there's a mismatch
            return 0;
        int xCapitalPos, yCapitalPos;
        if (!a.TryGetValue(x, out xCapitalPos)) {
            // compute xCapitalPos and add it to dictionary a
        }
        if (!a.TryGetValue(y, out yCapitalPos)) {
            // compute yCapitalPos and add it to dictionary a
        }
        int delta = xCapitalPos - yCapitalPos;
        if (0!=delta) {
            return delta;
        } else {
            return x.compareTo(y);
        }
    }
