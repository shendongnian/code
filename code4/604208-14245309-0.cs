    static void Main(string[] args)
        {
            int[] iMarks = new int[10];
            for(int x = 0; x < 10; x++)
                InsertMark(iMarks, x);
            Console.Read();
        }
        static void InsertMark(int[] piMarkArray, int piStuNum)
        {
            int iMark;
            Console.Write("Enter mark for student " + piStuNum + ": ");
            iMark = Convert.ToInt32(Console.ReadLine());
            while(iMark < 0 || iMark > 100)
            {
                Console.Write("Not a percentage. Enter again: ");
                iMark = Convert.ToInt32(Console.ReadLine());
            }
            //update array element with this mark
            piMarkArray[piStuNum] = iMark;
        }
    }
