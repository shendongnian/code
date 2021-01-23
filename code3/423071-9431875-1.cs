    public ReadOnlyCollection<Double> MyList {
            get {
                return myList.AsReadOnly();
            }
    }
    private List<Double> myList;
