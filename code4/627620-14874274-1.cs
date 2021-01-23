    private string __name;
    string name {
        get { return __name; }
        set {
            if(__name != value) {
                __name = value; // a non-trivial change
            }
        }
    }
