    private TWhatever[] _array;
    public ReadOnlyCollection<TWhatever> Elements { get; private set; }
    
    public ClassConstructor() {
        _array = new TWhatever[1000];
        this.Elements = new ReadOnlyCollection<TWhatever>( _array );
    }
