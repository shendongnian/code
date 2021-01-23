        public class ChartStrategyFactory
        {
            public IChartStrategy Create(string application, string test)
            {
                if (application == "Rapp" && test == "Total Test Runs")
                    return new RappTotalTestsRunChartStrategy();
                throw new NotSupportedException();
            }
        }
        public interface IChartStrategy
        {
            Chart CreateChart();
        }
        public class Chart
        {
            public string ChartTitle { get; set; }
            public string ChartData { get; set; }
            public bool TotalTestsWeb6Visible { get; set; }
            // create all properties you need
        }
        public class RappTotalTestsRunChartStrategy : IChartStrategy
        {
            public Chart CreateChart(){
                Chart chart = new Chart();
                chart.ChartData = GetDataFromDatabase();
                chart.ChartTitle = "Your Chart Title";
                chart.TotalTestsWeb6Visible = false;
                // continue assigning properties
                return chart;
            }
        }
