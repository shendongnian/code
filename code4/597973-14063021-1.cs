    [ServiceContract (Namespace = "https://_2Do") ]
    public interface IPerson
    {
        [OperationContract()]
        Person SetCustomer(List<Person> info);
    }
