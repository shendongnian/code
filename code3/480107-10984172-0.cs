    <WebService(Namespace:="http://tempura.org/")> _
    <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    <ScriptService()> _
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Public Class MyWebServices
        Inherits System.Web.Services.WebService
    
        <WebMethod()> _
        <ScriptMethod()> _
        Public Function MethodName As CustomReturnObject
            ...
        End Function
    
    End Class
