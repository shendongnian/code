    public static double sum(List<object> numbers) {
        double summation = 0.0;
        var parsedNumbers = numbers.Select(n => Convert.ToDouble(n));
        foreach (var parsedNumber in parsedNumbers) {
            summation += parsedNumber;
        }
        return summation;
    }
