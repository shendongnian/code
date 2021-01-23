    Sub TestCom()
        Dim c As CSharpCom.CSharpCom
        Set c = New CSharpCom.CSharpCom
        c.ShowMessageBox c.Format("{0} {1}!", "Hello", "World")
    End Sub
