        static List<T> MergeSort<T>(List<T> input) where T: IComparable
        {
            var length = input.Count;
            if (length < 2)
                return input;
            
            var left = MergeSort(input.GetRange(0, length / 2));
            var right = MergeSort(input.GetRange(length / 2, length - length / 2));
            var result = new List<T>();
            for (int leftIndex = 0, leftLength = left.Count, rightLength = right.Count, rightIndex = 0; leftIndex + rightIndex < length;)
            {
                if (rightIndex >= rightLength || leftIndex < leftLength && left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                    result.Add(left[leftIndex++]);
                else
                    result.Add(right[rightIndex++]);
            }
            return result;
        }
        static List<T> ThreadedMergeSort<T>(List<T> input) where T : IComparable
        {
            var length = input.Count;
            if (length < 2)
                return input;
            // this next part can be commented out if you want a "pure" mergesort, but it
            // doesn't make sense to merge sort very short sublists.
            if (length < 10)
            {
                for (int i = 0; i < length - 1; i++)
                    for (int j = i + 1; j < length; j++)
                        if (input[i].CompareTo(input[j]) > 0)
                        {
                            var tmp = input[i];
                            input[i] = input[j];
                            input[j] = tmp;
                        }
                return input;
            }
            List<T> left, right;
            if (length > 10000)
            {
                var taskLeft = Task<List<T>>.Factory.StartNew(() => { return ThreadedMergeSort(input.GetRange(0, length / 2)); });
                var taskRight = Task<List<T>>.Factory.StartNew(() => { return ThreadedMergeSort(input.GetRange(length / 2, length - length / 2)); });
                taskLeft.Wait();
                taskRight.Wait();
                left = taskLeft.Result;
                right = taskRight.Result;
            }
            else
            {
                left = ThreadedMergeSort(input.GetRange(0, length / 2));
                right = ThreadedMergeSort(input.GetRange(length / 2, length - length / 2));
            }
            var result = new List<T>();
            for (int leftIndex = 0, leftLength = left.Count, rightLength = right.Count, rightIndex = 0; leftIndex + rightIndex < length; )
            {
                if (rightIndex >= rightLength || leftIndex < leftLength && left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                    result.Add(left[leftIndex++]);
                else
                    result.Add(right[rightIndex++]);
            }
            return result;
        }
