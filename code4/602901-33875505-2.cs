    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets a collection of the Visual Studio instances that are running on this PC.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of DTE2)"/> that contains the running Visual Studio instances, if any.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    Public Shared Iterator Function GetVisualStudioInstances() As IEnumerable(Of DTE2)
        Dim rot As IRunningObjectTable = Nothing
        Dim enumMoniker As IEnumMoniker = Nothing
        Dim retVal As Integer = NativeMethods.GetRunningObjectTable(0, rot)
        If (retVal = 0) Then
            rot.EnumRunning(enumMoniker)
            Dim fetched As IntPtr = IntPtr.Zero
            Dim moniker As IMoniker() = New IMoniker(0) {}
            While (enumMoniker.Next(1, moniker, fetched) = 0)
                Dim bindCtx As IBindCtx = Nothing
                NativeMethods.CreateBindCtx(0, bindCtx)
                Dim displayName As String = ""
                moniker(0).GetDisplayName(bindCtx, Nothing, displayName)
                If (displayName.StartsWith("!VisualStudio")) Then
                    Dim obj As New Object
                    rot.GetObject(moniker(0), obj)
                    Yield DirectCast(obj, DTE2)
                End If
            End While
        End If
    End Function
    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets a <see cref="DTE2"/> object that represents the current Visual Studio instance that is running this project.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' A <see cref="DTE2"/> object that represents the current Visual Studio instance that is running this project.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    Public Shared Function GetCurrentVisualStudioInstance() As DTE2
        Dim currentInstance As DTE2 = Nothing
        Dim processName As String = Process.GetCurrentProcess.MainModule.FileName
        Dim instances As IEnumerable(Of DTE2) = DebugUtil.GetVisualStudioInstances
        For Each instance As DTE2 In instances
            For Each p As EnvDTE.Process In instance.Debugger.DebuggedProcesses
                If (p.Name = processName) Then
                    currentInstance = instance
                    Exit For
                End If
            Next p
        Next instance
        Return currentInstance
    End Function
