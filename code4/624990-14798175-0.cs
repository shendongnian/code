    private void CallCustomerSubInformationDialog<T>(int iMode, T iCustomerInformationObject) where T: GenericCustomerInformation, new()
    {
        //where T is either Emails or PhoneNumber
        GenericCustomerInformation genericInfoItem;
        //This is what you could try to do:
        genericInfoItem = new T();
    }
