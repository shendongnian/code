    using System;
    
    class Test
    {
        static void Main() 
        {
            string before = "xyz @ abc@123";
            string after = CustomRemove(before);
            Console.WriteLine(after); // Prints xyzabc@123
        }
    
        static string CustomRemove(string text)
        {
            int atSignIndex = text.IndexOf(" @ ");
            while (atSignIndex >= 0)
            {
                text = text.Remove(atSignIndex, 3);
                atSignIndex = text.IndexOf(" @ ");
            }
            return text;
        }
    }
