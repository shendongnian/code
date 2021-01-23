    // Names changed to fit .NET conventions
    public AnalysisResult[] PerformAnalysis(int[][] coefficients)
    {
        return Array.ConvertAll(coefficients, GetResult);
    }
    private AnalysisResult GetResult(int[] input)
    {
        switch (input.Length)
        {
            case 1: return GetResult(input[0]);
            case 2: return GetResult(input[0], input[1]);
            case 3: return GetResult(input[0], input[1], input[2]);
            case 4: return GetResult(input[0], input[1], input[2], input[3]);
            case 5: return GetResult(input[0], input[1], input[2], input[3], input[4]);
            default:
                throw new ArgumentException("Invalid number of inputs: " + input.Length);
        }
    }
