    'VB.NET:
    Imports System.ServiceModel
    <ServiceContract([Namespace]:="http://yournamespace", ConfigurationName:="MHS")> _
    Public Interface MHS
    //C#:
    using System.ServiceModel;
    [ServiceContract(Namespace="http://yournamespace", ConfigurationName="MHS")]
    public interface MHS
