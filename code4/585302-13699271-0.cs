        /// <summary>
        /// Performs a nCr Combination of the two numbers
        /// </summary>
        /// <param name="n">The Number</param>
        /// <param name="r">The Range</param>
        /// <returns></returns>
        public static double Combination(double n, double r)
        {
            /*
             * Formula for Combination: n! / (r! * (n - r)!)
             */
    
            // n and r should be integral values
            double rfloor = Math.Floor(r);
            double nfloor = Math.Floor(n);
            // Check for all invalid values of n and r.
            if ((n < 1) || (r < 0) || (r > n) || (r != rfloor) || (n != nfloor))
            {
                throw new Exception("Invalid Input to Combination Function: Number must be greater than Range");
            }
    
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }
