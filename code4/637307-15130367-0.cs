    void Init() {
       BoardPositions.CollectionChanged += BoardPositionsOnCollectionChanged;
    }
 
    public object Clone() {
        ...
        gameBoard.Init()
        return gameBoard;
    }
