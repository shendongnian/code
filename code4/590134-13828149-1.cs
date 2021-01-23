    static int Main(string[] args){
        if (args.Length != 1) {
            // We got more than 1 parameter, exiting with a code of -1.
            return -1;
        }
        if (args[0] != "abc123def456ghi") {
            // We got 1 parameter, but it wasn't right, exiting with a code of -2.
            return -2;
        }
        // Got 1 matching parameter
        // Code goes here
    }
