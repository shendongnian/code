        partial class Parameter<T> where T : AnAbstract
        {
            public static Parameter<T> NewParameter<T>() where T : AnAbstract
            {
                Parameter<T> parameter = new Parameter<T>();
                AnAbstract instance = (AnAbstract)Activator.CreateInstance(typeof(T));
                parameter.Name = instance.Name;
                // etc
                return parameter;
            }
        }
        private static Parameter<NumericImpl> ParameterNum = 
            Parameter<NumericImpl>.NewParameter();
