    public Stock GetUpdatedStock()
    {
         // Create a new instance here...
         return new Stock(this.FaceValue + DateTime.Now.MilliSecond, this.FaceValue * 100);
    }
