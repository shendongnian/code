    class SillyMath
        {
            public static int Plus(int number1, int number2)
            {
                return Plus(number1, number2, 0);
            }
        
            public static int Plus(int number1, int number2, int number3)
            {
                return Plus(number1, number2, number3, 0);
            }
        
            public static int Plus(int number1, int number2, int number3, int number4)
            {
                return number1 + number2 + number3 + number4;
            }
        }
