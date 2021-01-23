    IOutputVariable<double> output = something;
    dynamic input = typeof(BasicInputVariable<>)
                    .MakeGenericType(output
                                     .GetType()
                                     .GetGenericArguments()[0])
                    .GetConstructor(new Type[0])
                    .Invoke(new object[0]);
    input.Source = output;
