    using System.Reflection;
    
    GetInfoRequest objGetInfoRequest;
    Type getInfoRequestType = objGetInfoRequest.GetType();
    PropertyInfo[] myProps = getInfoRequestType.GetProperties();
