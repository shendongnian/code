    class Ansprechpartner
    {
        public static implicit operator Ansprechpartner(string s) {
            // put your conversion logic here 
            //    .. i.e: you can simply pass string s to a Ansprechpartner constructor
            Ansprechpartner a = new Ansprechpartner();
            return a;
        }
        public static implicit operator string(Ansprechpartner a)
        {
            if (a == null)
                return ""; 
            else 
                return a.ToString(); 
        }
        public Ansprechpartner()
        {
        }
        public override string ToString()
        {
            return Value;
        }
    }
