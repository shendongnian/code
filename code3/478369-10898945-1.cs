    List<int> ProcessLine(string line)
    {
      List<int> result = new List<int>();
      . . . split the line in a sequence of word / number of occurences . . . 
      . . . for each word / number of occurences . . .{
        int index = GetWordIndex(word);      
        while (index > result.Count) {
          result.Add(0);
        }  
        result.Insert(index, numberOfOccurences);
      }
      return result;
    }
