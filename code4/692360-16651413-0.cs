    enum MyEnum {
        Val1,
        Val2,
        Val3
    
    }
    
    class MyClass {
        void Foo(){
            string someInput = "Val2";
            
            MyEnum candidate;
            
            if(Enum.TryParse(someInput, out candidate)){
                // DO something with the enum
                DoSomething(candidate);
            }
            else{
                throw new VeryBadThingsHappened("someInput is not a valid MyEnum");
            }
        }
    }
