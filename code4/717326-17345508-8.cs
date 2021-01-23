    class C {
        public int a = useB(); //after initializer completes, a == 0
        int b = 5;
        int useB(){
            return b;  //use b regardless if it was initialized or not.
        }
    }
