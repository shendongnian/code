    using System;
    
    namespace OrOperand
    {
        class Program
        {
            static void Main(string[] args)
            {
                DisplayResult(true, true);
                DisplayResult(true, false);
                DisplayResult(false, true);
                DisplayResult(false, false);
            }
    
            private static void DisplayResult(bool left, bool right)
            {
                _left = left;
                _right = right;
    
                Console.WriteLine("Running " + left + " || " + right);
    
                if (Left() || Right())
                {
                    Console.WriteLine(_left + " || " + _right + " is true");
                }
                else
                {
                    Console.WriteLine(_left + " || " + _right + " is false");
                }
            }
    
            static bool _left = true;
            static bool _right = false;
    
            static bool Left()
            {
                Console.WriteLine("Left called");
                return _left;
            }
    
            static bool Right()
            {
                Console.WriteLine("Right called");
                return _right;
            }
    
        }
    }
