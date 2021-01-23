    Imports System.Xml
    Imports System.Data.SqlClient
    Public Class Form1
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim connetionString As String
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adpter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim xmlFile As XmlReader
        Dim sql As String
        Dim product_ID As Integer
        Dim Product_Name As String
        Dim product_Price As Double
        connetionString = "Data Source=servername;Initial Catalog=databsename;User ID=username;Password=password"
        connection = New SqlConnection(connetionString)
        xmlFile = XmlReader.Create("Product.xml", New XmlReaderSettings())
        ds.ReadXml(xmlFile)
        Dim i As Integer
        connection.Open()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            product_ID = Convert.ToInt32(ds.Tables(0).Rows(i).Item(0))
            Product_Name = ds.Tables(0).Rows(i).Item(1)
            product_Price = Convert.ToDouble(ds.Tables(0).Rows(i).Item(2))
            sql = "insert into Product values(" & product_ID & ",'" & Product_Name & "'," & product_Price & ")"
            command = New SqlCommand(sql, connection)
            adpter.InsertCommand = command
            adpter.InsertCommand.ExecuteNonQuery()
        Next
        connection.Close()
    End Sub
