    void TestString()
    {
        String print = "8A9B485ECDC56B6E0FD023D6994A57EEC49B0717";
        String newPrint = print.Trim().Replace(" ", "").ToUpper();
        Trace.TraceInformation("Strings are equal = {0}", (print == newPrint) && (print.Equals(newPrint)));
        Debug.Assert(print == newPrint);
        Debug.Assert(print.Equals(newPrint));
    }
