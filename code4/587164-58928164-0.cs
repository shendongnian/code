    public static void Main(string[] args)
        {
            int[] intList = new int[] { 1, 1, 2, 2, 3, 3, 3, 4, 4, 5 };
            foreach (var item in intList) {
                Console.Write(item + " ");
            }
            #region Calculating sequence and printing details
            int length = 1, start = 0, finalIndx = 0,
            bigSeqNum = 0, finalLen = 0;
            for (int i = 1; i < intList.Length; i++) {
                if (intList[i] == intList[start]) {
                    length++;
                    if (length > finalLen) {
                        finalLen = length;
                        finalIndx = start;
                        bigSeqNum = intList[start];
                    }
                } else {
                    start = i;
                    length = 1;
                }
            }
            Console.WriteLine("\nBig Seq. Num: " + bigSeqNum);
            Console.WriteLine("Start index: " + finalIndx);
            Console.WriteLine("Length: " + finalLen);
            Console.WriteLine();
            #endregion
        }
