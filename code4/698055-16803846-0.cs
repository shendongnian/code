    namespace WriteAndPresentUnicode {
        using System;
     
        class Program {
            static void Main(string[] args) {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("Пишем по-русски..."); // "We are writing in Russian..."
            } //Main
        } //class Program
    
    } //namespace WriteAndPresentUnicode
