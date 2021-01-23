    namespace ConsoleApplication1
    {
    
            class Program
            {
                static void Main(string[] args)
                {
                    char[] sw = "ab".ToCharArray();
                    swap(0, 1, ref sw );
                    string end = new string(sw);
                    Console.Write(end);
                }
        
                static void swap(int indexA, int indexB, ref char[] arr)
                {
                    char temp = arr[indexA];
                    arr[indexA] = arr[indexB];
                    arr[indexB] =temp;
                }
            }
        }
