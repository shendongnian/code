    class Setter { Vector[] Data; int Index; public double X { get { return Data[Index]; } set { Data[Index] = new Vector(value, Data[Index].Y); }}}
    
    
    public Setter this[int i]
        {
            get
            {
                return new Setter() { Data = elements, Index= i };
            }
        }
