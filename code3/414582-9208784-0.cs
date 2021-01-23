            static void WriteNumbers(int digits, int left=0,int number=0)
            {
               for(int i=left+1; i<10; i++)
               {
                   if(digits==1)
                   {
                       Console.WriteLine(number*10+i);
                   }
                   else
                   {
                       WriteNumbers(digits - 1, i, number*10 + i);
                   }
               }
            }
