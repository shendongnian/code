    public class Entry
    {
        // give meaningful names to the column values
        public int Column1 { get; set; }
        public int Column2 { get; set; }
        public int Column3 { get; set; }
        public int Column4 { get; set; }
        // overriden to make re-constructing the line for the file easier
        public override string ToString()
        {
            // assuming tab as the delimiter, replace with whatever you're using
            return string.Format("{0}\t{1}\t{2}\t{3}", this.Column1, this.Column2,
                this.Column3, this.Column4);
        }
    }
