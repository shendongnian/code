    class MyEnumHelper 
    { 
        void IsSpecialSet(MyEnum e) 
        { 
            return e in [MyEnum.A, MyEnum.C] 
            switch (e)
            {
                case MyEnum.A:
                case MyEnum.C:
                    return true;
                default:
                    return false;
            }
        } 
    } 
