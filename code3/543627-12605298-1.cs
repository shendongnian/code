    public class MetricTypeConverter : AutoMapper.TypeConverter<Metric, IMetricViewModel>
    {
        protected override IMetricViewModelConvertCore(Metric source)
        {
            switch (source.MetricType)
            {
                case MetricType.NumericMetric :
                    return new NumericMetric  {Value = source.NumericValue};
            
                case MetricType.TextMetric :
                    return new TextMetric  {Value = source.StringValue};
            }
        }
    }
