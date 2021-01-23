    public static List<Series> GetBccChartData(IEnumerable<MeterReadingsBccChartData> meterReadings)
    {
        List<Tuple<DateTime, double>> allData = new List<Tuple<DateTime, double>>();
        List<Series> series = new List<Series>();
        foreach (var item in meterReadings)
        {
            int lenght = item.DateAndValue.Count();
            object[,] data = new object[lenght, 2];
            for (int i = 0; i < lenght; i++)
            {
                allData.Add(item.DateAndValue[i]);
                data[i, 0] = item.DateAndValue[i].Item1;
                data[i, 1] = item.DateAndValue[i].Item2;
            }
            Series localSeries = new Series { Name = item.BranchName + " " + item.TypeName + " " + item.Unit, Data = new Data(data), Type = ChartTypes.Column };
            series.Add(localSeries);
        }
        // ortalama serisi hesaplanıyor.
        List<Tuple<DateTime, double>> averageData = allData.GroupBy(x => x.Item1).Select(x => Tuple.Create<DateTime, double>(x.Key, x.Average(item => item.Item2))).ToList();
        int avgDataLenght = averageData.Count();
        object[,] dataAvg = new object[avgDataLenght, 2];
        for (int i = 0; i < avgDataLenght; i++)
        {
            dataAvg[i, 0] = averageData[i].Item1;
            dataAvg[i, 1] = averageData[i].Item2;
        }
        Series avgSeries = new Series { Name = "Genel Toplam", Data = new Data(dataAvg), Type = ChartTypes.Line };
        series.Add(avgSeries);
        return series;
    }
