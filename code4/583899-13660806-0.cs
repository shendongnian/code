    using System;
    using System.Linq;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            string text = "\u00DCST";
            string normalized = text.Normalize(NormalizationForm.FormD);
            string asciiOnly = new string(normalized.Where(c => c < 128).ToArray());
            Console.WriteLine(asciiOnly);
        }    
    }
