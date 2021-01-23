    Imports System.Data.SqlClient
    Public Class Form1
    'Binding database table to DataGridView
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim con As SqlConnection = New SqlConnection("Data Source=.;Integrated Security=True;AttachDbFilename=|DataDirectory|\SqlDatabase.mdf")
        Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM Table1", con)
        con.Open()
        Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim myDataSet As DataSet = New DataSet()
        myDA.Fill(myDataSet, "MyTable")
        DataGridView1.DataSource = myDataSet.Tables("MyTable").DefaultView
        con.Close()
        con = Nothing
    End Sub
    End Class
