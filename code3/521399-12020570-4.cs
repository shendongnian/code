    Imports System.Runtime.CompilerServices
    Imports CrystalDecisions.CrystalReports.Engine
    Imports CrystalDecisions.Shared
    Imports CrystalDecisions.CrystalReports
    Namespace Extensions
    ''' <summary>
    ''' A set of extension methods to make manually working with Crystal Reports easier.
    ''' </summary>
    ''' <remarks>
    ''' Pieces of this code started in March of 2004 and have evolved over the last 8 years.
    ''' </remarks>
    Public Module CrystalReportExtensions
        '*********************************************************************************************************************
        '
        '            Module:  CrystalReportExtensions
        '      Initial Date:  03/26/2004
        '      Last Updated:  05/22/2012
        '     Programmer(s):  Blake Pell
        '
        '*********************************************************************************************************************
        ''' <summary>
        ''' Applies a new server name, SQL username and password to a ReportDocument.  This method can be used with any number
        ''' of database providers.
        ''' </summary>
        ''' <remarks></remarks>
        <Extension()> _
        Public Sub ApplyNewServer(ByVal report As ReportDocument, serverName As String, username As String, password As String)
            For Each subReport As ReportDocument In report.Subreports
                For Each crTable As Table In subReport.Database.Tables
                    Dim loi As TableLogOnInfo = crTable.LogOnInfo
                    loi.ConnectionInfo.ServerName = serverName
                    loi.ConnectionInfo.UserID = username
                    loi.ConnectionInfo.Password = password
                    crTable.ApplyLogOnInfo(loi)
                Next
            Next
            'Loop through each table in the report and apply the new login information (in our case, a DSN)
            For Each crTable As Table In report.Database.Tables
                Dim loi As TableLogOnInfo = crTable.LogOnInfo
                loi.ConnectionInfo.ServerName = serverName
                loi.ConnectionInfo.UserID = username
                loi.ConnectionInfo.Password = password
                crTable.ApplyLogOnInfo(loi)
                'If your DatabaseName is changing at runtime, specify the table location. 
                'crTable.Location = ci.DatabaseName & ".dbo." & crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1)
            Next
        End Sub
        ''' <summary>
        ''' Applies a new server name to the ReportDocument.  This method is SQL Server specific if integratedSecurity is True.
        ''' </summary>
        ''' <param name="report"></param>
        ''' <param name="serverName">The name of the new server.</param>
        ''' <param name="integratedSecurity">Whether or not to apply integrated security to the ReportDocument.</param>
        ''' <remarks></remarks>
        <Extension()> _
        Public Sub ApplyNewServer(report As ReportDocument, serverName As String, integratedSecurity As Boolean)
            For Each subReport As ReportDocument In report.Subreports
                For Each crTable As Table In subReport.Database.Tables
                    Dim loi As TableLogOnInfo = crTable.LogOnInfo
                    loi.ConnectionInfo.ServerName = serverName
                    If integratedSecurity = True Then
                        loi.ConnectionInfo.IntegratedSecurity = True
                    End If
                    crTable.ApplyLogOnInfo(loi)
                Next
            Next
            'Loop through each table in the report and apply the new login information (in our case, a DSN)
            For Each crTable As Table In report.Database.Tables
                Dim loi As TableLogOnInfo = crTable.LogOnInfo
                loi.ConnectionInfo.ServerName = serverName
                If integratedSecurity = True Then
                    loi.ConnectionInfo.IntegratedSecurity = True
                End If
                crTable.ApplyLogOnInfo(loi)
                'If your DatabaseName is changing at runtime, specify the table location. 
                'crTable.Location = ci.DatabaseName & ".dbo." & crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1)
            Next
        End Sub
        ''' <summary>
        ''' Applies a new database name to all of the tables in the Crystal Report.  If you do not wish to use a schemaName, pass
        ''' a blank string in for it.
        ''' </summary>
        ''' <param name="report">The Crystal Report document.</param>
        ''' <param name="databaseName">The name of the database.</param>
        ''' <param name="schemaName">The schema name if necessary.  If this is not needed, pass a blank in.</param>
        ''' <remarks>Depending on your database server, this may require a schema also.  For instance, in SQL Server
        ''' you may need NorthWind.dbo. </remarks>
        <Extension()> _
        Public Sub ApplyNewDatabaseName(ByVal report As ReportDocument, databaseName As String, schemaName As String)
            Dim prefix As String = ""
            If schemaName <> "" Then
                prefix = String.Format("{0}.{1}.", databaseName, schemaName)
            Else
                prefix = String.Format("{0}.", databaseName)
            End If
            'Loop through each table in the report and apply the new database name
            For Each crTable As Table In report.Database.Tables
                'If your DatabaseName is changing at runtime, specify the table location. 
                crTable.Location = String.Format("{0}{1}", prefix, crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1))
            Next
        End Sub
        ''' <summary>
        ''' Sets the Username, Password and ServerName property and/or the UseTrustedConnection property with the values listed in the
        ''' provided connection string.  Currently, only Sql Server is supported for automatically loading values from a connection
        ''' string.
        ''' </summary>
        ''' <param name="sqlConnectionString"></param>
        ''' <remarks></remarks>
        <Extension()> _
        Public Sub ApplyCredentialsFromConnectionString(report As ReportDocument, ByVal sqlConnectionString As String)
            ' Apply the connection information from the web.config file.
            Dim cb As New System.Data.SqlClient.SqlConnectionStringBuilder(sqlConnectionString)
            If cb.IntegratedSecurity = False Then
                ApplyNewServer(report, cb.DataSource, cb.UserID, cb.Password)
            Else
                ApplyNewServer(report, cb.DataSource, True)
            End If
        End Sub
        ''' <summary>
        ''' Checks to see if a parameter name exists in the reports parameter fields.  This only checks the top level of
        ''' the report.  The top level should propagate down any parameters that need to be passed down.
        ''' </summary>
        ''' <param name="paramName"></param>
        ''' <param name="report"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Extension()> _
        Public Function DoesParameterExist(ByVal report As ReportDocument, ByVal paramName As String) As Boolean
            If report Is Nothing Or report.ParameterFields Is Nothing Then
                Return False
            End If
            For Each param As ParameterField In report.ParameterFields
                If paramName = param.Name Then
                    Return True
                End If
            Next
            Return False
        End Function
        ''' <summary>
        ''' Takes a parameter string and places them in the corresponding parameters for the report.  The parameter string must 
        ''' be semi-colon delimited with the parameter inside of that delimited with an equal sign.  E.g.<br /><br />
        ''' 
        ''' <code>
        ''' lastName=Pell;startDate=1/1/2012;endDate=1/7/2012
        ''' </code>
        ''' 
        ''' </summary>
        ''' <param name="report">The Crystal Reports ReportDocument object.</param>
        ''' <param name="parameters">A parameter string representing name/values.  See the summary for usage.</param>
        ''' <remarks></remarks>
        <Extension()> _
        Public Sub ApplyParameters(report As ReportDocument, parameters As String)
            ApplyParameters(report, parameters, False)
        End Sub
        ''' <summary>
        ''' Takes a parameter string and places them in the corresponding parameters for the report.  The parameter string must 
        ''' be semi-colon delimited with the parameter inside of that delimited with an equal sign.  E.g.<br /><br />
        ''' 
        ''' <code>
        ''' lastName=Pell;startDate=1/1/2012;endDate=1/7/2012
        ''' </code>
        ''' 
        ''' </summary>
        ''' <param name="report">The Crystal Reports ReportDocument object.</param>
        ''' <param name="parameters">A parameter string representing name/values.  See the summary for usage.</param>
        ''' <param name="removeInvalidParameters">If True, parameters that don't exist in the Crystal Report will
        ''' be removed.  If False, these parameters will be left in and an exception will be thrown listing
        ''' the offending parameter name.</param>
        ''' <remarks></remarks>
        <Extension()> _
        Public Sub ApplyParameters(report As ReportDocument, parameters As String, removeInvalidParameters As Boolean)
            ' No parameters (or valid parameters) were provided.
            If String.IsNullOrEmpty(parameters) = True Or parameters.Contains("=") = False Then
                Exit Sub
            End If
            ' Get rid of any trailing or leading semi-colons that would mess up the splitting.
            parameters = parameters.Trim(";")
            ' The list of parameters split out by the semi-colon delimiter
            Dim parameterList As String() = parameters.Split(Chr(Asc(";")))
            For Each parameter As String In parameterList
                ' nameValue(0) = Parameter Name, nameValue(0) = Value
                Dim nameValue As String() = parameter.Split(Chr(Asc("=")))
                ' Validate that the parameter exists and throw a legit exception that describes it as opposed to the
                ' Crystal Report COM Exception that gives you little detail.  
                If report.DoesParameterExist(nameValue(0)) = False And removeInvalidParameters = False Then
                    Throw New Exception(String.Format("The parameter '{0}' does not exist in the Crystal Report.", nameValue(0)))
                ElseIf report.DoesParameterExist(nameValue(0)) = False And removeInvalidParameters = True Then
                    Continue For
                End If
                ' The ParameterFieldDefinition MUST be disposed of otherwise memory issues will occur, that's why
                ' we're going the "using" route.  Using should Dispose of it even if an Exception occurs.
                Using pfd As ParameterFieldDefinition = report.DataDefinition.ParameterFields.Item(nameValue(0))
                    Dim pValues As ParameterValues
                    Dim parm As ParameterDiscreteValue
                    pValues = New ParameterValues
                    parm = New ParameterDiscreteValue
                    parm.Value = nameValue(1)
                    pValues.Add(parm)
                    pfd.ApplyCurrentValues(pValues)
                End Using
            Next
        End Sub
    End Module
    End Namespace
