    class Vector 
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public int TableID { get; set; }
        public Vector(int column, int row, int tableID)
        {
            TableID = tableID;
            Row = row;
            Column = column;
        }
        public override int GetHashCode()
        {
            int hash = 19;
            hash += Column.GetHashCode();
            hash += Row.GetHashCode();
            hash += TableID.GetHashCode();
            return hash;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vector)) return false;
            Vector v2 = (Vector)obj;
            return Column == v2.Column && Row == v2.Row && TableID == v2.TableID;
        }
    }
