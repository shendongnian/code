        /// <summary>
        /// Fills an array with a default value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array to fill with a default value</param>
        /// <param name="value">The default value</param>
        public static void MemSet<T>(T[] array, T value)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            int block = 32, index = 0;
            int length = Math.Min(block, array.Length);
            //Fill the initial array
            while (index < length)
            {
                array[index++] = value;
            }
            length = array.Length;
            while (index < length)
            {
                Buffer.BlockCopy(array, 0, array, index, Math.Min(block, length - index));
                index += block;
                block *= 2;
            }
        }
