    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(response))
    {
        string name = descriptor.Name;
        object value = descriptor.GetValue(response);
        StatusDataReponse statusData = value as StatusDataReponse; 
        if (statusData == null)
        {
            Console.WriteLine("{0}={1}", name, value);
        }
        else
        {
            //loop thorugh StatusDataReponse properties
        }
