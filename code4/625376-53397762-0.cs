    static void Main(string[] args)
            {
                //let us define array and vars
                var arr = new int[]{ 100, -3, 95,100,95, 177,-5,-4,177,101 };
   
                int biggest =0, secondBiggest=0;
                for (int i = 0; i < arr.Length; ++i)
                    {
                    int arrItem = arr[i];
                    if(arrItem > biggest)
                    {
                        secondBiggest = biggest; //always store the prev value of biggest 
                                                 //to second biggest...
                        biggest = arrItem;
                     }
                    else if (arrItem > secondBiggest && arrItem < biggest) //if in our 
                     //iteration we will find a number that is bigger than secondBiggest and smaller than biggest 
                       secondBiggest = arrItem;
                }
                Console.WriteLine($"Biggest Number:{biggest}, SecondBiggestNumber: 
                                  {secondBiggest}");
                Console.ReadLine(); //make program wait
            }
