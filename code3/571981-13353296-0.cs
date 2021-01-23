    using System;
    using System.Text;
    
    namespace SplitOnUppercase
    {
        class Program
        {
            static void Main()
            {
                const string text = "UltraCorrosion-ResistantCoated Alloy-Steel";
                var result = new StringBuilder(text.Length);
                for (var i = 0; i < text.Length - 1; i++)
                {
                    result.Append(text[i]);
                    if (text[i] != ' ' && text[i] != '-' && char.IsUpper(text[i + 1]))
                        result.Append(' ');
                }
                result.Append(text[text.Length - 1]);
    
                Console.WriteLine(result);
            }
        }
    }
