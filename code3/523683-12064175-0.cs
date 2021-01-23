    class MathClass {
        public int Add(int number1, int number2) {
            return DoSomeMathOperation(number1, number2, theAddingIsActuallyDoneHere); // The method "theAddingIsActuallyDoneHere" below is what gets called.
        }
        private int theAddingIsActuallyDoneHere(int number1, int number2) {
            return number1 + number2;
        }
        public int Multiply(int number1, int number2) {
            return DoSomeMathOperation(number1, number2, theMultiplicationIsDoneHere); // The method "theMultiplicationIsDoneHere" is what gets called.
        }
        private int theMultiplicationIsDoneHere(int number1, int number2) {
            return number1 * number2;
        }
        public int DoSomeMathOperation(int number1, int number2, Func<int, int, int> mathOperationFunc) {
            return mathOperationFunc(number1, number2); // This is where you call the method passed in above.
        }
    }
