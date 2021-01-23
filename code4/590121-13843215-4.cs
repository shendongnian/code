    public struct MyData
    {
        public MyData(string description, uint colourID, uint quantity)
        {
            this.Description = description;
            this.ColourID = colourID;
            this.Quantity = quantity;
        }
        public readonly string Description;
        public readonly uint ColourID;
        public readonly uint Quantity;
    } 
