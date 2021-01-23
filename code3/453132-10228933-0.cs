    ''' <summary>
    ''' If AppSettings: CatchallIgnoredExtensions doesn't exist, these are the default extensions to ignore in the catch-all route
    ''' </summary>
    ''' <remarks></remarks>
    Public Const DefaultIgnoredExtensions As String = ".jpg,.gif,.png"
    ''' <summary>
    ''' For the catch-all route, checks the AppSettings: CatchallIgnoredExtensions to determine if the route should be ignored.
    ''' Generally this is for images - if we got to here that means the image was not found, and there's no need to follow this route
    ''' </summary>
    Public Function Match(ByVal httpContext As System.Web.HttpContextBase, ByVal route As System.Web.Routing.Route, ByVal parameterName As String, ByVal values As System.Web.Routing.RouteValueDictionary, ByVal routeDirection As System.Web.Routing.RouteDirection) As Boolean Implements System.Web.Routing.IRouteConstraint.Match
        If routeDirection = Routing.RouteDirection.IncomingRequest Then
            Dim friendlyUrl As String = Nothing
            If values.TryGetValue("friendlyUrl", friendlyUrl) AndAlso Not String.IsNullOrEmpty(friendlyUrl) Then
                If friendlyUrl.Contains(".") Then
                    Dim catchallIgnoredExtensions As String = ConfigurationManager.AppSettings("CatchallIgnoredExtensions")
                    ' only set defaults if the setting is not found - user may not want to ignore any extensions
                    If catchallIgnoredExtensions Is Nothing Then
                        catchallIgnoredExtensions = DefaultIgnoredExtensions
                    End If
                    ' replace spaces and period to standardize, surround the extensions in commas for searching
                    catchallIgnoredExtensions = "," & catchallIgnoredExtensions.Replace(" ", "").Replace(".", "").ToLowerInvariant() & ","
                    Dim extension As String = System.IO.Path.GetExtension(friendlyUrl).Replace(".", "")
                    If catchallIgnoredExtensions.Contains("," & extension & ",") Then
                        Return False
                    End If
                End If
            End If
        End If
        Return True
    End Function
