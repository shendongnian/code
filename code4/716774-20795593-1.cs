    private IEnumerable<Type> GetExcelChartTypes()
            {
                IEnumerable<Type> items = new List<Type>();
                try
                {
                    DocumentFormat.OpenXml.Drawing.Charts.LineChart linechart = new DocumentFormat.OpenXml.Drawing.Charts.LineChart();
                    items = Assembly.GetAssembly(linechart.GetType()).GetTypes().Where(S => S.Name.EndsWith("Chart"));
                }
                catch
                {
    
                }
                return items;
            }
