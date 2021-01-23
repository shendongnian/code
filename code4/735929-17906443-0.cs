    public async Task<string> HighLevelTask(string input1, string input2, Action completed) {
        Task<string[]> parts = Task.WhenAll(Part1(input1), Part2(input2));
        string[] results = await parts;
        completed();
        return string.Join(",", results);
    }
    public async Task<string> Part1(string input) {
        var result1 = await Stage1(input);
        var result2 = await Stage2(result1);
        return result2;
    }
