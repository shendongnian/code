    Imports EnvDTE    
    Imports EnvDTE80    
    Imports EnvDTE90
        
    Public DTE As EnvDTE.DTE
    Dim version As String
    
    DTE = System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.9.0")    
    version = DTE.Version    
    MsgBox("The visual studio version is {0}", version)
