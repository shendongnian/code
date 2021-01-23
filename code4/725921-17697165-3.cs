    using System;
    using System.Diagnostics;
    
    namespace Numbers2
    {
        class Program
        {
            /// <summary>
            /// Maximum of supported digits. 
            /// </summary>
            const int MAXLENGTH = 20;
            /// <summary>
            /// Contains the number in a decimal format. Index 0 is the righter number. 
            /// </summary>
            private static byte[] digits = new byte[MAXLENGTH];
            /// <summary>
            /// Contains the products of the numbers. Index 0 is the righther number. The left product is equal to the digit on that position. 
            /// All products to the right (i.e. with lower index) are the product of the digit at that position multiplied by the product to the left.
            /// E.g.
            /// 234 will result in the product 2 (=first digit), 6 (=second digit * 2), 24 (=third digit * 6)
            /// </summary>
            private static long[] products = new long[MAXLENGTH];
            /// <summary>
            /// The length of the decimal number. Used for optimisation. 
            /// </summary>
            private static int currentLength = 1;
            /// <summary>
            /// The start value for the calculations. This number will be used to start generated products. 
            /// </summary>
            const long INITIALVALUE = 637926372435;
            /// <summary>
            /// The number of values to calculate. 
            /// </summary>
            const int NROFVALUES = 10000;
    
            static void Main(string[] args)
            {
                Console.WriteLine("Started at " + DateTime.Now.ToString("HH:mm:ss.fff"));
    
                // set value and calculate all products
                SetValue(INITIALVALUE);
                UpdateProducts(currentLength - 1);
    
                for (long i = INITIALVALUE + 1; i <= INITIALVALUE + NROFVALUES; i++)
                {
                    int changedByte = Increase();
    
                    Debug.Assert(changedByte >= 0);
    
                    // update the current length (only increase because we're incrementing)
                    if (changedByte >= currentLength) currentLength = changedByte + 1;
    
                    // recalculate products that need to be updated
                    UpdateProducts(changedByte);
    
                    //Console.WriteLine(i.ToString() + " = " + products[0].ToString());
                }
                Console.WriteLine("Done at " + DateTime.Now.ToString("HH:mm:ss.fff"));
                Console.ReadLine();
            }
    
            /// <summary>
            /// Sets the value in the digits array (pretty blunt way but just for testing)
            /// </summary>
            /// <param name="value"></param>
            private static void SetValue(long value)
            {
                var chars = value.ToString().ToCharArray();
    
                for (int i = 0; i < MAXLENGTH; i++)
                {
                    int charIndex = (chars.Length - 1) - i;
                    if (charIndex >= 0)
                    {
                        digits[i] = Byte.Parse(chars[charIndex].ToString());
                        currentLength = i + 1;
                    }
                    else
                    {
                        digits[i] = 0;
                    }
                }
            }
    
            /// <summary>
            /// Recalculate the products and store in products array
            /// </summary>
            /// <param name="changedByte">The index of the digit that was changed. All products up to this index will be recalculated. </param>
            private static void UpdateProducts(int changedByte)
            {
                // calculate other products by multiplying the digit with the left product
                bool previousProductWasZero = false;
                for (int i = changedByte; i >= 0; i--)
                {
                    if (previousProductWasZero)
                    {
                        products[i] = 0;
                    }
                    else
                    {
                        if (i < currentLength - 1)
                        {
                            products[i] = (int)digits[i] * products[i + 1];
                        }
                        else
                        {
                            products[i] = (int)digits[i];
                        }
                        if (products[i] == 0)
                        {
                            // apply 'zero optimisation'
                            previousProductWasZero = true;
                        }
                    }
                }
            }
    
            /// <summary>
            /// Increases the number and returns the index of the most significant byte that changed. 
            /// </summary>
            /// <returns></returns>
            private static int Increase()
            {
                digits[0]++;
                for (int i = 0; i < MAXLENGTH - 1; i++)
                {
                    if (digits[i] == 10)
                    {
                        digits[i] = 0;
                        digits[i + 1]++;
                    }
                    else
                    {
                        return i;
                    }
                }
                if (digits[MAXLENGTH - 1] == 10)
                {
                    digits[MAXLENGTH - 1] = 0;
                }
                return MAXLENGTH - 1;
            }
        }
    }
