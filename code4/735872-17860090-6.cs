    public object Clone()
    {
        MyGame cloned = new MyGame();
        cloned.Start = this.Start; // Copied (cloned) because value type
        cloned.Board = this.Board; // This is not a copy, just a reference!
    }
