    namespace Reverse_the_string
    {
        class Program
        {
            static void Main(string[] args)
            {
            
               // string text = "my name is bharath";
                string text = Console.ReadLine();
                string[] words = text.Split(' ');
                int k = words.Length - 1;
                for (int i = k;i >= 0;i--)
                {
                    Console.Write(words[i] + " " );
                    
                }
                
                Console.ReadLine();
    
            }
        }
    }
