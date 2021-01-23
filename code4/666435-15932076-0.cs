        using System;
        interface IPerl
        {
            void Read();
        }
        class TestA : IPerl
        {
            public void Read()
            {
        	Console.WriteLine("Read TestA");
            }
        }
        class TestB : IPerl
        {
            public void Read()
            {
        	Console.WriteLine("Read TestB");
            }
        }
        class Program
        {
            static void Main()
            {
        	IPerl perl = new TestA(); // Create instance.
        	perl.Read(); // Call method on interface.
            }
        }
