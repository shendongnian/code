    AutoMapper.Mapper.Configuration
            .CreateMap<Organisation, OrganisationViewModel>();
    AutoMapper.Mapper.Configuration
            .CreateMap<Metric, IMetricViewModels>()
            .ConvertUsing<MetricTypeConverter>();
