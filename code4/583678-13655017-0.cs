    public double CalculateDailyProjectMaxPumpSpm(DateTime date, string start = null, string end = null)
    {
        Log("Calculating Daily Pump stroke Max...");
        var spm = Enumerable
             .Range(0, _pumpOneSpm.Count)
             .Where(x => _date[x].Equals(date) &&
                         (start == null ||
                          (DateTime.Compare(_time[x], DateTime.Parse(start)) > 0 && 
                           DateTime.Compare(_time[x], DateTime.Parse(end)) < 0)))
             .SelectMany(x => new [] { _pumpOneSpm[x], _pumpTwoSpm[x] });
        return _dailyProjectMaxSpm = Math.Round(spm.Max(), 2, MidpointRounding.AwayFromZero);
    }
