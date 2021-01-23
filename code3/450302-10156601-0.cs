    List<String> gameState;
    using (var reader = new StreamReader(filename))
        gameState = reader.ReadLine().Split(new[] {','});
    if (gameState[0] == "")
        gameState[0] = playerName
    else
        gameState[1] = playerName;
    using (var writer = new StreamWriter(filename))
        writer.WriteLine(String.Join(",", gameState));
