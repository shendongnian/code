    bClass
    {
        ....
        public bClass(bClass b)
            {
                ...
            }
    }
    public class dClass : bClass
    {
        public dClass(bClass b, int exVal):base(b)
        {
            extraVal = exVal;
        }
    ....
    }
