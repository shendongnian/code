    Imports System.Data
    Imports System.Data.OleDb
    Imports System.Data.SqlClient
    Imports System.Web.Configuration
     
    //Declare Variables - Edit these based on your particular situation
    Dim sSQLTable As String = "TempTableForExcelImport"
    Dim sExcelFileName As String = "myExcelFile.xls"
    Dim sWorkbook As String = "[WorkbookName$]"
     
    //Create our connection strings
    Dim sExcelConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath(sExcelFileName) & ";Extended Properties=""Excel 8.0;HDR=YES;"""
    Dim sSqlConnectionString As String = WebConfigurationManager.ConnectionStrings("MyConnectionString").ToString
     
       
    //Series of commands to bulk copy data from the excel file into our SQL table
    Dim OleDbConn As OleDbConnection = New OleDbConnection(sExcelConnectionString)
    Dim OleDbCmd As OleDbCommand = New OleDbCommand(("SELECT * FROM " & sWorkbook), OleDbConn)
    OleDbConn.Open()
    Dim dr As OleDbDataReader = OleDbCmd.ExecuteReader()
    
    
    Using bulkCopy As New System.Data.SqlClient.SqlBulkCopy(con) 
    bulkCopy.DestinationTableName = "tblExcel" 
    
    //Define ColumnMappings: source(Excel) --destination(DB Table column)   
    bulkCopy.ColumnMappings.Add("col1", "col1") 
    bulkCopy.ColumnMappings.Add("col2", "col2") 
    :
    :
    bulkCopy.ColumnMappings.Add("col2", ExcelRows [i]["DateColumn"].ToString("yyyy/MM/dd")) //This is for date
    
    bulkCopy.WriteToServer(dr) 
    
    End Using 
    bulkCopy.WriteToServer(dr)
    OleDbConn.Close()
