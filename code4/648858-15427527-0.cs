     class Program {
        static void Main(string[] args) {
            int[] values = { 9, 1, 4, 15, -5, -41, -8, 78, 145, 14 };
            Console.WriteLine(FindMaxSubarray(values, 0, values.Length - 1));
        }
        public struct MaxSubArray {
            public int Low;
            public int High;
            public int Sum;
            public override string ToString() {
                return String.Format("From: {0} To: {1} Sum: {2}", Low, High, Sum);
            }
        }
        private static MaxSubArray FindMaxSubarray(int[] a, int low, int high) {
            var res = new MaxSubArray {
                Low = low,
                High = high,
                Sum = a[low]
            };
            if (low == high) return res;
            var mid = (low + high) / 2;
            var leftSubarray = FindMaxSubarray(a, low, mid);
            var rightSubarray = FindMaxSubarray(a, mid + 1, high);
            var crossingSubarray = FindMaxCrossingSubarray(a, low, mid, high);
            if (leftSubarray.Sum >= rightSubarray.Sum &&
                leftSubarray.Sum >= crossingSubarray.Sum)
                return leftSubarray;
            if (rightSubarray.Sum >= leftSubarray.Sum &&
                     rightSubarray.Sum >= crossingSubarray.Sum)
                return rightSubarray;
            return crossingSubarray;
        }
        private static MaxSubArray FindMaxCrossingSubarray(int[] a, int low, int mid, int high) {
            var maxLeft = 0;
            var maxRight = 0;
            var leftSubarraySum = Int32.MinValue;
            var rightSubarraySum = Int32.MinValue;
            var sum = 0;
            for (var i = mid; i >= low; i--) {
                sum += a[i];
                if (sum <= leftSubarraySum) continue;
                leftSubarraySum = sum;
                maxLeft = i;
            }
            sum = 0;
            for (var j = mid + 1; j <= high; j++) {
                sum += a[j];
                if (sum <= rightSubarraySum) continue;
                rightSubarraySum = sum;
                maxRight = j;
            }
            return new MaxSubArray {
                Low = maxLeft,
                High = maxRight,
                Sum = leftSubarraySum + rightSubarraySum
            };
        }
    }
