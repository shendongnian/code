    interface IChart {
        bool IsCharItemNeeded(IChartItem item);
        void AddChartItem(IChartItem item);
    }
    IEnumerable<T> Charts<T>() where T : new, IChart {
        var res = List<T>();
        foreach (QueueCommand command in MyBigQueue) {
            var chart = new T();
            foreach (IChartItem item in command) {
                if (chart.IsCharItemNeeded(item)) {
                    chart.AddChartItem(item);
                }
            }
            res.Add(chart);
        }
        return res;
    }
