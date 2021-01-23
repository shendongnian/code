      <DataMember()>
        Public Property loginObject As csCSLogin
        Public Sub New()
            MyBase.New()
            Me.loginObject = New csCSLogin
        End Sub
