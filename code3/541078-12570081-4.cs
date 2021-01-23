      Public ReadOnly Property ReportServerUrl() As System.Uri Implements Microsoft.Reporting.WebForms.IReportServerConnection.ReportServerUrl
        Get
          Return New Uri(System.Configuration.ConfigurationManager.AppSettings.Get("ReportServerUrl"))
        End Get
      End Property
    
      Public ReadOnly Property Timeout() As Integer Implements Microsoft.Reporting.WebForms.IReportServerConnection.Timeout
        Get
          Return CInt(System.Configuration.ConfigurationManager.AppSettings.Get("ReportServerTimeout"))
        End Get
      End Property
    
      Public ReadOnly Property Cookies() As System.Collections.Generic.IEnumerable(Of System.Net.Cookie) Implements Microsoft.Reporting.WebForms.IReportServerConnection2.Cookies
        Get
          Return Nothing
        End Get
      End Property
    
      Public ReadOnly Property Headers() As System.Collections.Generic.IEnumerable(Of String) Implements Microsoft.Reporting.WebForms.IReportServerConnection2.Headers
        Get
          Return Nothing
        End Get
      End Property
    
      Public Function GetFormsCredentials(ByRef authCookie As System.Net.Cookie, ByRef userName As String, ByRef password As String, ByRef authority As String) As Boolean Implements Microsoft.Reporting.WebForms.IReportServerCredentials.GetFormsCredentials
        'Not using form credentials
        authCookie = Nothing
        userName = Nothing
        password = Nothing
        authority = Nothing
    
        Return False
      End Function
    
      Public ReadOnly Property ImpersonationUser() As System.Security.Principal.WindowsIdentity Implements Microsoft.Reporting.WebForms.IReportServerCredentials.ImpersonationUser
        Get
          'Use the default windows user.  Credentials will be
          'provided by the NetworkCredentials property.
          Return Nothing
        End Get
      End Property
    
      Public ReadOnly Property NetworkCredentials() As System.Net.ICredentials Implements Microsoft.Reporting.WebForms.IReportServerCredentials.NetworkCredentials
        Get
          Return Net.CredentialCache.DefaultCredentials
        End Get
      End Property
    End Class
