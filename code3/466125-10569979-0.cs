    ''CConexion Class:
            
    Imports System.Data.SqlClient
    Imports System.Data.OleDb
    Imports System.Data
    
    Public Class CConexion
    
    #Region "Private Variables"
    
        Dim sOleDbConnectionString As String = String.Empty
        Dim conexionOleDb As New OleDbConnection()
    
    #End Region
    
    #Region "Con_Ole"
    
        Public Interface IConexionOleDb
    
            Property retConexionOleDb() As OleDbConnection
            Sub retOpenOleDb()
            Sub retCloseOleDb()
    
        End Interface
    
        Public Property retConexionOleDb() As OleDbConnection
    
            Get
                Return conexionOleDb
            End Get
            Set(ByVal value As OleDbConnection)
    
            End Set
    
        End Property
    
        Public Sub retOpenOleDb()
    
            If Not conexionOleDb.State = System.Data.ConnectionState.Open Then
                conexionOleDb.Open()
            End If
    
        End Sub
    
        Public Sub retCloseOleDb()
    
            If Not conexionOleDb.State = ConnectionState.Closed Then
                conexionOleDb.Close()
            End If
    
        End Sub
    
    #End Region
    
    #Region "Constructors"
    
        Public Sub New()
    
        End Sub
    
        Public Sub New(ByVal rutaOleDb As String)
    
            sOleDbConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" _
                                                        & "Data Source=" & rutaOleDb _
                                                        & ";" & "Extended Properties=Excel 12.0;"
            conexionOleDb.ConnectionString = sOleDbConnectionString
    
        End Sub
    
    #End Region
            
    End Class
            
    ''ExcelRecord Class:
            
    Public Class ExcelRecord
    
        Private _RId As Short = 0
        Public Property RId() As Short
            Get
                Return _RId
            End Get
            Set(ByVal value As Short)
                _RId = value
            End Set
        End Property
    
        Private _RText As String = String.Empty
        Public Property RText() As String
            Get
                Return _RText
            End Get
            Set(ByVal value As String)
                _RText = value
            End Set
        End Property
    
        Public Sub New()
    
        End Sub
    
        Public Sub New(ByVal Rid As Short, ByVal RText As String)
            Me.RId = Rid
            Me.RText = RText
        End Sub
    
    End Class
            
    ''ExcelParser Class:
            
    Imports System.Data.OleDb
    Imports System.Collections.Generic
    
    Public Class ExcelParser
    
        Private Function InsertRecords(ByVal objExcelRecord As List(Of ExcelRecord)) As Boolean
    	''Your code for insertion here
            Return True
        End Function
    
        Public Function ReadExcel(ByVal filePath As String) As Short
    
            Dim cn As New CConexion(filePath)
            Dim dr As OleDbDataReader
            Dim OperationState As Boolean = False
            Dim objExcelRecords As New List(Of ExcelRecord)
    
            Try
    
                Dim cmd As New OleDbCommand("Select * from [Hoja1$]", cn.retConexionOleDb)
    
                cn.retOpenOleDb()
                dr = cmd.ExecuteReader
    
                While dr.Read    
                   
                    Dim objExcelRecord As New ExcelRecord(CShort(dr(0)), CStr(dr(1)))
                    objExcelRecords.Add(objExcelRecord)
    
                End While
    
                OperationState = InsertRecords(objExcelRecords)
                CType(dr, IDisposable).Dispose()
    
            Catch ex As Exception
    
            Finally
    
                cn.retCloseOleDb()
                cn.retConexionOleDb.Dispose()
    
            End Try
    
            Return OperationState
    
        End Function
    
    End Class
