    static class PropertyInfoExtensions
    {
        private static int PropertyOrder(this PropertyInfo propInfo)
        {
            int output;
            var orderAttr = (ParameterOrderAttribute)propInfo.GetCustomAttributes(typeof(ParameterOrderAttribute), true).SingleOrDefault();
            output = orderAttr != null ? orderAttr.Order : Int32.MaxValue;
            return output;
        }
    }
