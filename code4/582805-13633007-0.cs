    Imports System.Web.Services
    Imports System.ComponentModel
    
    <System.Web.Script.Services.ScriptService()> _
    <System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
    <System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    <ToolboxItem(False)> _
    Public Class LightboxService
    	Inherits WebService
    
    	<WebMethod(EnableSession:=True)> _
    	Public Function AddToLightbox(ByVal filename As String) As String
    		Dim user As String = CStr(Session("username"))
    '...etc.
