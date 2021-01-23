    public static class DataSourceRequestExtensions
    {
        /// <summary>
        /// Enable flattened properties in the ViewModel to be used in DataSource.
        /// </summary>
        public static void Deflatten(this DataSourceRequest dataSourceRequest)
        {
            DeflattenFilters(dataSourceRequest.Filters);
            foreach (var sortDescriptor in dataSourceRequest.Sorts)
            {
                sortDescriptor.Member = DeflattenString(sortDescriptor.Member);
            }
        }
        private static void DeflattenFilters(IList<IFilterDescriptor> filters)
        {
            foreach (var filterDescriptor in filters)
            {
                if (filterDescriptor is CompositeFilterDescriptor)
                {
                    var descriptors
                        = (filterDescriptor as CompositeFilterDescriptor).FilterDescriptors;
                    DeflattenFilters(descriptors);
                }
                else
                {
                    var filter = filterDescriptor as FilterDescriptor;
                    filter.Member = DeflattenString(filter.Member);
                }
            }
        }
        private static string DeflattenString(string source)
        {
            return source.Replace('_', '.');
        }
    }
