    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports EnvDTE90
    Imports EnvDTE90a
    Imports EnvDTE100
    Imports System.Diagnostics
    
    Public Module AttachToProcess
    
        Public Sub DebugMyDLL()
            DTE.ExecuteCommand("Build.BuildSelection")
            Dim ApplicationExePath As String = "C:\Program Files (x86)\foo\bar.exe"
            Shell(ApplicationExePath)
            Try
                Dim dbg2 As EnvDTE80.Debugger2 = DTE.Debugger
                Dim trans As EnvDTE80.Transport = dbg2.Transports.Item("Default")
                Dim dbgeng(2) As EnvDTE80.Engine
                dbgeng(0) = trans.Engines.Item("Managed (v4.0)")
                dbgeng(1) = trans.Engines.Item("Native")
                Dim proc2 As EnvDTE80.Process2 = dbg2.GetProcesses(trans, "<QualifierName>").Item("bar.exe")
                proc2.Attach2(dbgeng)
            Catch ex As System.Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    
    End Module
