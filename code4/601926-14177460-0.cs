    //original
    class Outer<A>
    {
        class Inner1 //: Outer<Inner1>
        {
            Inner1 field;
            //from inheritance
            class Inner2 : Outer<Inner1.Inner2>
            {
                Inner2 field;
            }
        }
    }
    //modified for Inner.Inner
    class Outer<A>
    {
        class Inner1 //: Outer<Inner1>
        {
            Inner1.Inner2 field;
            //from inheritance
            class Inner2 : Outer<Inner1.Inner2>
            {
                Inner2.Inner3 field;
            }
        }
    }
