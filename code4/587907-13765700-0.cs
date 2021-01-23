        /// <summary>
        /// Obtain all the combinations of the elements contained in a list
        /// </summary>
        /// <param name="subsetDimension">Subset Dimension</param>
        /// <returns>IEnumerable containing all the differents subsets</returns>
        public static IEnumerable<List<T>> CalcCombinations<T>(this List<T> list, int subsetDimension)
        {
            //First of all we will create a binary matrix. The dimension of a single row
            //must be the dimension of list 
            //on which we are working (we need a 0 or a 1 for every single element) so row
            //dimension is to obtain a row-length = list.count we have to
            //populate the matrix with the first 2^list.Count binary numbers
            int rowDimension = Convert.ToInt32(Math.Pow(2, list.Count));
            //Now we start counting! We will fill our matrix with every number from 1 
            //(0 is meaningless) to rowDimension
            //we are creating binary mask, hence the name
            List<int[]> combinationMasks = new List<int[]>();
            for (int i = 1; i < rowDimension; i++)
            {
                //I'll grab the binary rapresentation of the number
                string binaryString = Convert.ToString(i, 2);
                //I'll initialize an array of the apropriate dimension
                int[] mask = new int[list.Count];
                //Now, we have to convert our string in a array of 0 and 1, so first we 
                //obtain an array of int then we have to copy it inside our mask 
                //(which have the appropriate dimension), the Reverse()
                //is used because of the behaviour of CopyTo()
                binaryString.Select(x => x == '0' ? 0 : 1).Reverse().ToArray().CopyTo(mask, 0);
                //Why should we keep masks of a dimension which isn't the one of the subset?
                // We have to filter it then!
                if (mask.Sum() == subsetDimension) combinationMasks.Add(mask);
            }
            //And now we apply the matrix to our list
            foreach (int[] mask in combinationMasks)
            {
                List<T> temporaryList = new List<T>(list);
                //Executes the cycle in reverse order to avoid index out of bound
                for (int iter = mask.Length - 1; iter >= 0; iter--)
                {
                    //Whenever a 0 is found the correspondent item is removed from the list
                    if (mask[iter] == 0)
                        temporaryList.RemoveAt(iter);
                }
                yield return temporaryList;
            }
        }
    }
