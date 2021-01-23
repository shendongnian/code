    public bool checkProgress(char letterGuess, char[] wordToGuess, char[] displayString)
    {
        bool result = false;
        for (int a = 0; a < wordToGuess.Length; a++)
        {
            if (wordToGuess[a] == letterGuess)
            {
                displayString[a] = letterGuess;
                result = true;
            }
        }
        return result;
    }
.
    var word = "hello world".ToCharArray();
    var mask = word.Select(c => c==' '?' ':'*').ToArray();
    Console.WriteLine(checkProgress('l', word, mask)); // will output "true"
    Console.WriteLine(checkProgress('z', word, mask)); // will output "false"
    Console.WriteLine(new string(mask)); // will output "**ll* ***l*"
