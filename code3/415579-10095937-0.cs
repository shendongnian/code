    public static class DotNetHighChartsExtensions
    {
        public static object[] ToPieChartSeries(this WhateverThatTypeIs data)
        {
            var returnObject = new List<object>();
            foreach ( var item in data )
            {
                returnObject.Add(new object[] { item.name, item.count});
            }
            return returnObject.ToArray();
        }
    }
