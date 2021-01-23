    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            createControls()        
        End Sub
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If IsPostBack Then
                setcontrolvalues()
            End If
        End Sub
    
        Private Sub createControls()
            Dim txt1 As New TextBox
            Dim txt2 As New TextBox
            txt1.ID = "txt1"
            txt1.EnableViewState = True
            txt2.EnableViewState = True
            txt2.ID = "txt2"
            PlaceHolder1.Controls.Add(txt1)
            PlaceHolder1.Controls.Add(txt2)
        End Sub
    
        Private Sub setcontrolvalues()
            Dim txt1 As TextBox
            Dim txt2 As TextBox
            txt1 = CType(PlaceHolder1.FindControl("txt1"), TextBox)
            txt1.Text = "text1"
            txt2 = CType(PlaceHolder1.FindControl("txt2"), TextBox)
            txt2.Text = "text2"
        End Sub
