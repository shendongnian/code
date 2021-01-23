    using System;
    
    static class Program {
        static void Main() {
            try{
                func1();
            } catch(Exception e) {
                // works fine: FileNotFoundException
                Console.WriteLine(e);
            }
        }
        static void func1(){
            func2();
        }    
        static void func2() {
            string filePath = "doesnot.exist";
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
        }
    }
