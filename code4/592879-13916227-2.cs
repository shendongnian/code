    [OperationContract]
    public Employee GetEmployee(int clientId, String id)
    {
        var employee = new Employee();
        //here you might use a mapping table between the clients and the exposed data members
        if (clientId == 1)
        {
            employee.IsSSNSerializable = true;
        }
        return employee;
    }
