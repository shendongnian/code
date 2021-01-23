    public class Child : Parent
    {
        public void Print(bool onlyCallFather)
        {
        if(onlyCallFather)
            base.Print();
        else
            Print();
        }
    }
