    Option Explicit On
    Option Strict On
    'Option Infer On
    
    Imports Microsoft.VisualBasic
    
    Namespace SO13035027
    <ComClass(WinMergeScript.ClassId, WinMergeScript.InterfaceId, WinMergeScript.EventsId)> _
    Public Class WinMergeScript
    
    #Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String =     "9b9bbe1c-7b20-4826-b12e-9062fc4549a2"
    Public Const InterfaceId As String = "b0f2aa59-b9d0-454a-8148-9715c83dbb72"
    Public Const EventsId As String =    "8f4f9c82-6ba3-4c22-8814-995ca1050de2"
    #End Region
    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub
    Public Function HelloWorld() As String
     Return "Hello, world!"
    End Function
    
    End Class
    End Namespace
