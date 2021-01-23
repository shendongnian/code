    Console.WriteLine("How many words are you going to enter?");
    int wordCount = int.Parse(Console.ReadLine());
    
    string[] words = new string[wordCount];
    for (int i = 0; i < words.Length; i++)
    {
      Console.WriteLine("Please enter your word");
      words[i] = Console.ReadLine();
    }
    Console.WriteLine("Please enter a letter: ");
    string searchChar = Console.ReadLine();
    for (int i = 0; i < words.Length; i++)
    {
      string word = words[i];
      if (word.Contains(searchChar) == true)
      {
         Console.WriteLine(word);
      }
    }
