    class Person {
        String Firstname;
        String Lastname;
        String ZipCode;
    }
    public Person GetPersonData(Integer Id) {
        //All your MySQL Code here
        Person ReturnData = new Person();
        ReturnData.Firstname = mySqlDataReader[0].ToString();
        ReturnData.Lastname = mySqlDataReader[1].ToString();
        ReturnData.ZipCode = mySqlDataReader[2].ToString();
        return ReturnData;
    }
