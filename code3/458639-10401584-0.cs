    public static int[] hit(int n)
        {
            List<int> nums = new List<int>();
            
            nums.Add(n);
            
            int x = 0;
            int Right = 0;
            int Left = 0;
            do
            {
                //even num
                if (n % 2 == 0)
                {
                    x = n / 2;
                    //result of division is also even 20/2 = 10 
                    if (x % 2 == 0 || n>10 )
                    {
                        nums.Add(x);
                        n = x;
                    }
                    else
                    {
                        nums.Add(x + 1);
                        nums.Add(x - 1);
                        n = x - 1;
                    }
                }
                    //numbers that can only be divided by 3
                else if (n % 3 == 0)
                {
                    x = n / 3;//46/3 =155
                     Right = x * 2;//155*2 = 310
                     Left = x;//155
                    nums.Add(Right);
                    nums.Add(Left);
                    n = x;
                }
                    //numbers that can only be divided by 5
                else
                {
                    x = n / 2;
                    Right = x + 1;
                    Left = x;
                    nums.Add(Right);
                    nums.Add(Left);
                    n = Left;
                }
            } while (n > 2);
            nums.Add(1);
            nums.Reverse();
            int[] arr = nums.ToArray();
            return arr;
        }
