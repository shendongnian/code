        class Potato
        {
        }
        class Potato1 : Potato
        {
            public Potato1(object[] param) { }
        }
        class Potato2 : Potato
        {
            public Potato2(object[] param);
        }
        enum MyEnum
        {
            E1, E2
        }
        Dictionary<MyEnum, Func<object[], Potato>> dict = new Dictionary<MyEnum, Func<object[], Potato>>(){
                {MyEnum.E1,(d)=>new Potato1(d)},
                {MyEnum.E2,(d)=>new Potato2(d)}
            };
        Potato Factory(MyEnum e, object[] param)
        {
            return dict[e](param);
        }
