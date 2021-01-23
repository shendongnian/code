    Imports System.Data
    Imports System.Data.OleDb
    Imports System.Data.SqlClient
    Imports System.Web.Configuration
     
    
        'Declare Variables - Edit these based on your particular situation
        Dim sSQLTable As String = "TempTableForExcelImport"
        Dim sExcelFileName As String = "myExcelFile.xls"
        Dim sWorkbook As String = "[WorkbookName$]"
    
     
    
        'Create our connection strings
        Dim sExcelConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath(sExcelFileName) & ";Extended Properties=""Excel 8.0;HDR=YES;"""
        Dim sSqlConnectionString As String = WebConfigurationManager.ConnectionStrings("MyConnectionString").ToString
         
    
    'Execute a query to erase any previous data from our destination table
    Dim sClearSQL = "DELETE FROM " & sSQLTable
    Dim SqlConn As SqlConnection = New SqlConnection(sSqlConnectionString)
    Dim SqlCmd As SqlCommand = New SqlCommand(sClearSQL, SqlConn)
    SqlConn.Open()
    SqlCmd.ExecuteNonQuery()
    SqlConn.Close()
     
    'Series of commands to bulk copy data from the excel file into our SQL table
    Dim OleDbConn As OleDbConnection = New OleDbConnection(sExcelConnectionString)
    Dim OleDbCmd As OleDbCommand = New OleDbCommand(("SELECT * FROM " & sWorkbook), OleDbConn)
    OleDbConn.Open()
    Dim dr As OleDbDataReader = OleDbCmd.ExecuteReader()
    Dim bulkCopy As SqlBulkCopy = New SqlBulkCopy(sSqlConnectionString)
    bulkCopy.DestinationTableName = sSQLTable
    bulkCopy.WriteToServer(dr)
    OleDbConn.Close()
