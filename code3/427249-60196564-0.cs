     public class SentenceCapitalization
    {
        public static string SentenceCapitalizations(string str)
        {
            string[] strArray = str.Split(' ');//split words
            string capString = "";
            string capStr = "";
            foreach (string s in strArray)
            {
                if (s.Length > 0 && s != string.Empty)
                {
                    capStr = s[0].ToString().ToUpper();
                    capString += capStr + s.Remove(0, 1) +" ";
                }
            }
            return capString.TrimEnd();
        }
    }
    public class Step
    {
        public static void Steps(int num)
        {
            for (int row = 1; row <= num; row++)
            {
                string str = "";
                for (int col = 1; col <= num; col++)
                {
                    if (row == col || row > col)
                        str += "#";
                    else if (row < col)
                        str += " ";
                }
                Console.WriteLine(str);
            }
        }
        public static void RevSteps(int num)
        {
            int count = 0;
            for (int row = 1; row <= num; row++)
            {
                string str = "";
                for (int col = 1; col <= num; col++)
                {
                    count = num - row;
                    if(col> count)
                    {
                        str += "#";
                    }
                    else 
                        str += " ";
                }
                Console.WriteLine(str);
            }
        }
    }
    public class Pyramid
    {
        public static void PyramidSteps()
        {
            Console.Write("enter number for Pyramid steps: ");
            int num = (int) Math.Round(Convert.ToDecimal(Console.ReadLine()));
            int rows = num;
            int cols = num + (num - 1);
            int emptyLCols, emptyRCols;
            for (int row = 1; row <= rows; row++)
            {
                string str = "";
                emptyLCols = rows - row;
                emptyRCols = rows + row;
                for (int col = 1; col <= cols; col++)
                {
                    if(col<=emptyLCols || col>=emptyRCols)
                        str += " ";                    
                    else 
                        str += "#";
                }
                Console.WriteLine(str);
            }
        }
    }
    public class vowels
    {
        public static void Vowels()
        {
            Console.Write("enter String: ");
            string vowelStr = Console.ReadLine().ToLower();
            int count = 0;
            
            for(int i=0; i < vowelStr.Length; i++)
            {
                char c = vowelStr[i];
                if ("aeiou".Contains(c))
                {
                    count++;
                }
            }
            Console.WriteLine("total vowels...."+count);
        }
    }
    public class SpiralMatrix
    {
        public static void SpiralMatrixs()
        {
            Console.Write("enter number for SpiralMatrixs: ");
            int num = (int)Math.Round(Convert.ToDecimal(Console.ReadLine()));
            int[,] arr = new int[num,num];
            int startColumn=0, startRow=0, endColumn=num-1, endRow=num-1;
            int counter = 1;
           for(int k=0; (startColumn < endColumn && startRow <= endRow) && k<num; k++)
            {
                for(int i= startColumn; i <= endColumn; i++)
                {
                    arr[startRow, i] = counter;
                    counter++;
                }
                startRow++;
                for (int i = startRow; i <= endRow; i++)
                {
                    arr[i, endColumn] = counter;
                    counter++;
                }
                endRow--;
                startColumn++;
                k++;
            }
           
        }
    }
    public class Sorting
    {
        public static int RecFactorials(int num)
        {
            if (num == 0)
                return 1;
            else
                return num * RecFactorials(num - 1);
        }
        public static int[] BubbleSort(int[] array)
        {
            for(int partIndex=array.Length-1; partIndex > 0; partIndex--)
            {
                for(int i=0; i < partIndex; i++)
                {
                    if(array[i]> array[i + 1])
                    {
                        Swap(array, i, i + 1);
                    }
                }                
            }
            return array;
        }
        public static int[] SelectionSort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                int largeIndexAt = 0;
                for(int i = 1; i <= partIndex; i++)
                {
                    if (array[i] > array[largeIndexAt])
                    {
                        largeIndexAt = i;
                    }
                }
                Swap(array, largeIndexAt, partIndex);
            }
            return array;
        }
        public static int[] InsertionSort(int[] array)
        {
            for (int partIndex = 0; partIndex < array.Length ; partIndex++)
            {
                int currUnsort = array[partIndex];
                int i = 0;
                for ( i = partIndex; i >0 && array[i-1] > currUnsort; i--)
                {
                    array[i] = array[i - 1];
                }
                array[i] = currUnsort;
            }
            return array;
        }
        public static void Swap(int[] arr, int i, int j)
        {
            int arrPre = arr[j];
            arr[j] = arr[i];
            arr[i] = arrPre; 
        }
    }
    public class Lists
    {
        public static void SortList()
        {
            List<int> lsArray = new List<int>();
            for(int i=0; i < 16; i++)
            {
                lsArray.Add(i);
                LogList(lsArray);
            }
            LogList(lsArray);
            for(int i=10; i>0; i--)
            {
                lsArray.RemoveAt(i-1);
                LogList(lsArray);
            }
            lsArray.TrimExcess();
            LogList(lsArray);
            Console.ReadLine();
        }
        public static void LogList(List<int> ls)
        {
            Console.WriteLine("count: {0}, Capacity:{1}", ls.Count, ls.Capacity);
        }
        public static void ApiMembers()
        {
            var list = new List<int>() { 1, 0, 5, 3, 4 };
            list.Sort();
            int binarySearch = list.BinarySearch(5);
            list.Reverse();
            ReadOnlyCollection<int> readonlylist = list.AsReadOnly();
            readonlylist.Reverse();
            int count=list.Count();
            var listCustomers = new List<Customer>
            {
                new Customer{BirthDate=new DateTime(1988,08,12), Name="name1"},
                new Customer{BirthDate=new DateTime(1978,08,04), Name="name2"},
                new Customer{BirthDate=new DateTime(1978,09,04), Name="name3"},
                new Customer{BirthDate=new DateTime(1988,08,12), Name="name1"},
                new Customer{BirthDate=new DateTime(1998,08,12), Name="name1"},
                new Customer{BirthDate=new DateTime(1888,08,12), Name="name1"}
            };
            listCustomers.Sort((left, right) =>
            {
                if (left.BirthDate > right.BirthDate)
                    return 1;
                if (right.BirthDate > left.BirthDate)
                    return -1;
                return 0;
            });
        }
    }
    public class Customer
    {
        public DateTime BirthDate;
        public string Name;
    }
    public class SingleLinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }
        private bool IsEmpty => Count == 0;
        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }
        private void AddFirst(Node<T> linkedListNode)
        {
            //save off the current head
            Node<T> tmp = Head;
            Head = linkedListNode;
            Head.Next = tmp;
            Count++;
            if(Count==1)
            { Tail = Head; }
        }
        public void RemoveFirst()
        {
            if(IsEmpty)
            {
                throw new InvalidOperationException();
            }
            Head = Head.Next;
            if (Count == 1)
                Tail = null;
            Count--;
        }
        public void RemoveLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            if(Count==1)
            {
                Head = Tail = null;
            }
            else
            {
                //find the penultimate node
                var current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                Tail = current;
            }
            Count--;
        }
        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }
        private void AddLast(Node<T> node)
        {
            if (IsEmpty)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Tail = node;
            Count++;
        }
       
    }
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node(T value)
        {
            this.Value = value;
        }
    }
     public static void RevSteps(int num)
        {
            int count = 0;
            for (int row = 1; row <= num; row++)
            {
                string str = "";
                for (int col = 1; col <= num; col++)
                {
                    count = num - row;
                    if(col> count)
                    {
                        str += "#";
                    }
                    else 
                        str += " ";
                }
                Console.WriteLine(str);
            }
        }
        public static void plusMinus()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            plusMinus(arr);
        }
        static void plusMinus(int[] arr)
        {
            int count = arr.Length;
            decimal pC = 0, bC = 0, zC = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] > 0)
                {//positive
                    pC++;
                }
                else if (arr[i] < 0)
                {
                    bC++;
                }
                else if (arr[i] == 0)
                {
                    zC++;
                }
            }
            Console.WriteLine((pC / count).ToString("N6"));
            Console.WriteLine((bC / count).ToString("N6"));
            Console.WriteLine((zC / count).ToString("N6"));
        }
