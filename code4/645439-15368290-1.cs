    [TestClass]
    public class TestStackOverflowDetection
    {
        [TestMethod]
        public void TestDetectStackOverflow()
        {
            try
            {
                InfiniteRecursion();
            }
            catch (StackOverflowException e)
            {
                Debug.WriteLine(e);
            }
        }
        private static int InfiniteRecursion(int i = 0)
        {
            // Insert the following call in all methods that
            // we suspect could be part of an infinite recursion 
            CheckForStackOverflow(); 
            // Force an infinite recursion
            var j = InfiniteRecursion(i) + 1;
            return j;
        }
        private static void CheckForStackOverflow()
        {
            var stack = new System.Diagnostics.StackTrace(true);
            if (stack.FrameCount > 1000) // Set stack limit to 1,000 calls
            {
                // Output last 10 frames in the stack
                foreach (var f in stack.GetFrames().Reverse().Take(30).Reverse())
                    Debug.Write("\tat " + f);
                // Throw a stack overflow exception
                throw new StackOverflowException();
            }
        }
