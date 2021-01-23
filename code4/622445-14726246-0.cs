        /// <summary>
        /// Using Func<int,int,int>, we get generic documentation
        /// </summary>
        public Func<int,int,int> UsingFunc{ get; }
        /// <summary>
        /// Example of a delegate with XML documentation as if it was a method.
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>Whatever it returns</returns>
        public delegate int CustomDelegate(int left, int right);
        /// <summary>
        /// Using a custom delegate to get full documentation.
        /// </summary>
        public CustomDelegate UsingCustomDelegate{ get; }
