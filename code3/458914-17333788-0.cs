    static void aMethod()
    {
        string[] wordsToDelete = { "aa", "bb" };
        string[] Lines = System.IO.File.ReadAllLines(TextFilePath)
            .Where(n => n.IsNotAnyOf(wordsToDelete)).ToArray();
        IO.File.WriteAllLines(TextFilePath, Lines);
    }
    static private bool IsNotAnyOf(this string n, string[] wordsToDelete)
    {    for (int ct = 0; ct < wordsToDelete.Length; ct++)
             if (n == wordsToDelete[ct]) return false;
         return true;
    }
`
