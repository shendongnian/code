    Public Class WebTespRegionComuna
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'ControlSystema.GetSearhRegionList(ddlRegion)
            Dim _ControlSystema As New ControlSystema
            With _ControlSystema
                .MtRegionList(ddlRegion)
            End With
            _ControlSystema = Nothing
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Function GetProComunas(regionId As String) As List(Of ComunaList)
        Dim _ControlSystema As New ControlSystema
        Dim _lista As List(Of ComunaList)
        With _ControlSystema
            _lista = .GetSearchComunaList(regionId)
        End With
        _ControlSystema = Nothing
        Return _lista
    End Function
    Private Sub btnGuardarDatos_Click(sender As Object, e As System.EventArgs) Handles btnGuardarDatos.Click
        Try
            Dim valorcomuna As String = ddlComuna.SelectedValue
            valorcomuna = txtComunaHiden.Text
            Dim valorregion As String = ddlRegion.SelectedValue.ToString()
            Dim _valor As String = "punto de quiebre"
        Catch ex As Exception
        End Try
    End Sub End Class
