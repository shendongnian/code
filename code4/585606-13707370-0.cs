    public bool this[int x, int y]
    {    
        get
        {
            var index= x * this.width + y; //CALCULATE INDEX ON GET
            return this[index];
        }
        set
        {
            var index= x * this.width + y;//CALCULATE INDEX ON SET
            this[index] = value;
        }
    }
