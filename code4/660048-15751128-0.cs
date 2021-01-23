    public T GetPropertyValue<T>(string property)
    {
        var propertyInfo = GetType().GetProperty(property);
        return (T)propertyInfo.GetValue(this, null);
    }
    var emp = employee.GetPropertyValue<Employee>("Designation");
    var salary = emp.Salary;
