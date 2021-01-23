    public class Ratio : IMyList<double>
    {
        private Dictionary<int, IList<double>> _results;
        private int _currentSeries;
        private int _seriesResults;
        private int _op1Index;
        private int _op2Index;
        private bool _bDone;
        public Ratio()
        {
            _op1Index = 0;
            _op2Index = 1;
            _currentSeries = 0;
            _seriesResults = 1;
        }
        public void SetList(IList<double> series)
        {
            // the zero entry is the first result set
            _results = new Dictionary<int, IList<double>>();
            _results.Add(_currentSeries, series);
            _results.Add(_seriesResults, new List<double>());
        }
        public bool IsDone()
        {
            return _bDone;
        }
        public double GetOperand1()
        {
            return _results[_currentSeries][_op1Index];
        }
        public double GetOperand2()
        {
            return _results[_currentSeries][_op2Index];
        }
        public double Calculate(double op1, double op2)
        {
            return op1 / op2;
        }
        public void SetResult(double result)
        {
            _results[_seriesResults].Add(result);
        }
        public void Next()
        {
            _op1Index++;
            _op2Index++;
            if (_op2Index >= _results[_currentSeries].Count())
            {
                if (_results[_seriesResults].Count == 1)
                {
                    _bDone = true;
                }
                else
                {
                    _currentSeries++;
                    _seriesResults++;
                    _results.Add(_seriesResults, new List<double>());
                    _op1Index = 0;
                    _op2Index = 1;
                }
            }
        }
        public Dictionary<int, IList<double>> GetResults()
        {
            return _results;
        }
    }
