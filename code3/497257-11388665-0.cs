    public class Class1
        {
            public static string SeparateName(string fullName)
            {
                string[] wordsInText = fullName.Split(' ');
                return wordsInText[0];
            }
        }
