    private static List<double> _intervals = new List<double>
    {
        1.0 / 1000 / 1000,
        1.0 / 1000,
        1,
        1000,
        60 * 1000,
        60 * 60 * 1000
    };
    private static List<string> _units = new List<string>
    {
        "ns",
        "µs",
        "ms",
        "s",
        "min",
        "h"
    };
    
    public string FormatUnits(double milliseconds, string format = "#.#")
    {
        var interval = _intervals.Last(i=>i<=milliseconds);
        var index = _intervals.IndexOf(interval);
        
        return string.Concat((milliseconds / interval).ToString(format) , " " , _units[index]);
    }
