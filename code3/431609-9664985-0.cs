    string customerClassName = string.Format("DataProcessor.{0}Processor", ConfigurationManager.AppSettings.Get("Customer"));
    Type customerClass = Assembly.GetExecutingAssembly().GetType(customerClassName);
    ConstructorInfo ctor = customerClass.GetConstructor(System.Type.EmptyTypes);
    Logger.Log("Instantiating class " + customerClassName);
    object instance = ctor.Invoke(null);
    customerClass.GetMethod("Run").Invoke(instance, new object[] { args });
