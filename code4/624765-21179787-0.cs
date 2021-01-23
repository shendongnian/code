    interface IHourlyChart {
        IEnumerable<IHourlyChart> Create();
    }
    class HourlyDeviceChart : IHourlyChart 
    {
        public IEnumerable<IHourlyChart> Create()
        {
            return repository.HourlyDeviceChart();
        }
    }
    class HourlyUsersChart : IHourlyChart 
    {
        public IEnumerable<IHourlyChart> Create()
        {
            return repository.HourlyUsersChart();
        }
    }
    IEnumerable<T> GetChart<T>() where T : IHourlyChart, new()
    {
        return (IEnumerable<T>)new T().Create();
    }
