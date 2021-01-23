    var inputSet = myString.ToCharArray();
    var P2 = new Permutations<char>(inputSet, 
          GenerateOption.WithRepetition);
    string format2 = "Permutations of {{A A C}} with Repetition; size = {0}";
    Console.WriteLine(String.Format(format2, P2.Count));
    foreach(IList<char> p in P2) {
      Console.WriteLine(String.Format("{{{0} {1} {2}}}", p[0], p[1], p[2]));
    }
