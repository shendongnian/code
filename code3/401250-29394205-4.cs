    class Position{
    ...
        [Column]
        public int Pieces{
            get{
                this.pieces = this.Transformers.Count;
                return this.pieces;
            }
            set{ this.pieces = value; }
        }
    ...
    }
