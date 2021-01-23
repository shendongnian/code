    public static void MyDataContractJsonSerializer(
        object objToSerialize, 
        Type objType, 
        Stream output
    )
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(objType);
        ser.WriteObject(output, objToSerialize);
    }
