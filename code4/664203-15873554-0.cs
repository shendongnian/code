            class Potato
            {
            }
    
            class Potato1 : Potato
            {
            }
    
            class Potato2 : Potato
            {
            }
    
            enum MyEnum
            {
                E1,E2
            }
    
            Dictionary<MyEnum, Func<Potato>> dict = new Dictionary<MyEnum, Func<Potato>>(){
                {MyEnum.E1,()=>new Potato1()},
                {MyEnum.E2,()=>new Potato2()}
            };
    
            Potato Factory(MyEnum e)
            {
                return dict[e].Invoke();
            }
