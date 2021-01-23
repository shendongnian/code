        Imports Microsoft.VisualBasic
        
        Public Class MyHTTPHandler
            Implements IHttpHandler
            Implements IRequiresSessionState
        
            Dim myFile As String
        
            Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
                Get
                    Return True
                End Get
            End Property
        
            Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
                myFile = context.Request.Path
                If myFile.ToLower.Contains("members private files") OrElse myFile.ToLower.Contains("members%20private%20files") Then
                    If System.Web.HttpContext.Current.Session("Login") Is Nothing Then
                        context.Response.Redirect("~/NotAuthorized.aspx")
                    Else
                        If myFile.ToLower.Contains("privatefiles") Then
                            StartDownload(context, myFile)
                        Else
                            If IsMemberAuthoraizedToDownloadFile(context) Then
                                StartDownload(context, myFile)
                            Else
                                context.Response.Redirect("~/NotAuthorized.aspx")
                            End If
                        End If
                    End If
                Else
                    StartDownload(context, myFile)
                End If
            End Sub
        
            Private Sub StartDownload(ByVal context As HttpContext, ByVal downloadFile As String)
                context.Response.Buffer = True
                context.Response.Clear()
                context.Response.AddHeader("content-disposition", "attachment; filename=" & downloadFile)
                context.Response.ContentType = "application/pdf"
                context.Response.WriteFile(downloadFile)
            End Sub
        
    // this is just my function to check whether the user is valid or not
            Private Function IsMemberAuthoraizedToDownloadFile(ByVal context As HttpContext) As Boolean
                Dim MyGroupMemberc As New GroupMembersControl
                Dim MemberGroupsL As Generic.List(Of GroupMembers) = MyGroupMemberc.GetMemberGroups(System.Web.HttpContext.Current.Session("Login"))
                Dim MyGroupC As New MemberGroupControl
                Dim MyGroup As MemberGroup
                For Each groupmember As GroupMembers In MemberGroupsL
                    MyGroup = MyGroupC.GetMemberGroup(groupmember.GroupID)
                    If myFile.ToLower.Contains(MyGroup.Name.ToLower) Then
                        Return True
                    End If
                Next
                Return False
            End Function
        
        End Class
