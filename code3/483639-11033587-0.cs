    public class SpreadSheetCell
    {
        public int X {get; set;}
        public int Y {get; set;}
        public string Contents {get; set;}
    }
    ...
    SpreadSheetCell[,] spreadSheet = new SpreadSheetCell[100,100];
    spreadSheet[1, 2] = new SpreadSheetCell
                            {
                              X = 1,
                              Y = 2,
                              Contents = "Something goes here..."
                            };
    
