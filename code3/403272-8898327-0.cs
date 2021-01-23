     static void Main(string[] args)
     {
         //This will loop indefinitely 
         while (true)
         {
             /*Output the character which was pressed. This will duplicate the input, such
              that if you press 'a' the output will be 'aa'. To prevent this, pass true to
              the ReadKey overload*/
             Console.Write(Console.ReadKey().KeyChar);
         }
     }
