    int now = DateTime.Now.Month;
                    string month;
                    if (now < 10)
                    {
                        month = "0" + now.ToString();
                    }
                    else
                    {
                        month = now.ToString();
                    }
    
    mySearcher.Filter = ("(&(objectClass=user)(|(employeeHireDate=" + month + "*)(employeeBirthDate=" + month + "*)))");
