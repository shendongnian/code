        partial class Parameter<T> where T : AnAbstract
        {
            public static Parameter<T> NewParameter<T>() where T : AnAbstract
            {
                Parameter<T> parameter = new Parameter<T>();
                AnAbstract instance = (AnAbstract)Activator.CreateInstance(typeof(T));
                parameter.Name = instance.Name;
                parameter.Description = instance.Description;
                parameter.IsNumeric = instance.IsNumeric;
                if (parameter.IsNumeric) 
                {
                    parameter.Min = (instance as ANumericAbstract).Min;
                    parameter.Max = (instance as ANumericAbstract).Max; 
                }
                else 
                {
                  foreach (Object val in (parameter as ANonNumericAbstract).objects)
                  {
                      parameter.Values.Add(val);
                  }
                }
                return parameter;
            }
        }
