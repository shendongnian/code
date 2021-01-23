        public class SomeClass {
          private void SomeMethod(SomeClass obj){
             //....
          }
          private void AnotherMethod(){
            SomeMethod(this);//pass the current instance into SomeMethod
            //.....
          }
        }
