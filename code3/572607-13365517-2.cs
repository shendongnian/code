        Permanent = 0,
        Contract = 1,
    }
    int value = EmployeeType.Contract.ToEnumValue<int, EmployeeType>(); // 1
    EmployeeType employeeType = value.ToEnumType<int, EmployeeType>();  // Contract
