            Console.WriteLine("Enter an integer number to factorise");
         
            int ans = 1;
            int a = int.Parse(Console.ReadLine());
            for (int i = 1; i <= a; i++)
            {
                ans = ans * i;
            }
            Console.WriteLine(ans.ToString());
            Console.ReadLine();
             
        }
    }
}
