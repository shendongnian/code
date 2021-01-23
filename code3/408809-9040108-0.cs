       Console.WriteLine(" Enter number " + (i + 1));
       Int32.TryParse(Console.ReadLine(), out temp);
       a[i] = temp;
                //Decision Making Logic 
                if (min > temp)
                {
                    min = temp;
                    minpos = i;
                }
                if (max < temp)
                {
                    max = temp;
                    maxpos = i;
                }
            }
