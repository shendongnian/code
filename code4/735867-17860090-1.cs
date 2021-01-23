    public object Clone()
    {
        MyGame cloned = new MyGame();
        cloned.Start = this.Start;
        cloned.Board = (Board)this.Board.Clone();
    }
