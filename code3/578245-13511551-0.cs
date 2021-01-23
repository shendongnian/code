    using System;
    using System.Threading; 
    public static class Program {
        public static void Main() {
            bool created; 
            using(new Semaphore(0, 1, "SomeUniqueStringIdentifyingMyApp", out created)) {
                if(created) {
                    //This thread created kernel object so no other instance of this app must be running
                } else {
                    //This thread opens existing kernel object with the same string name which means 
                    //that another instance of this app must be running. 
                }
            }
        }
    }
