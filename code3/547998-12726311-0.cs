    class TypeA
    {
        void MyFun(TypeA a, TypeA b, TypeA c, TypeA d)
        {
            // Implentation irrelavent
        }
    }
    class TypeB : TypeA
    {
        void MyFun(TypeB a, TypeB b, TypeB c, TypeB d)
        {
            base.MyFun(a, b, c, d)
        }
    }
