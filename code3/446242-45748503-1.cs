    Public Function IsAdministrator() As Boolean
        Static bResult As Boolean? = Nothing
        Try
            If bResult Is Nothing Then
                bResult = New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
                If Not bResult Then
                    Dim oContext As PrincipalContext = Nothing
                    Try
                        Domain.GetComputerDomain()
                        oContext = TryCast(New PrincipalContext(ContextType.Domain), PrincipalContext)
                    Catch
                        'Fall through to machine check
                    End Try
                    If oContext Is Nothing Then oContext = New PrincipalContext(ContextType.Machine)
                    Dim oPrincipal As UserPrincipal = UserPrincipal.FindByIdentity(oContext, WindowsIdentity.GetCurrent().Name)
                    If oPrincipal IsNot Nothing Then
                        bResult = oPrincipal.GetAuthorizationGroups().Any(Function(p) _
                            p.Sid.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid) OrElse
                            p.Sid.IsWellKnown(WellKnownSidType.AccountDomainAdminsSid) OrElse
                            p.Sid.IsWellKnown(WellKnownSidType.AccountAdministratorSid) OrElse
                            p.Sid.IsWellKnown(WellKnownSidType.AccountEnterpriseAdminsSid))
                    End If
                End If
            End If
        Catch
            bResult = False
        End Try
        Return bResult.GetValueOrDefault(False)
    End Function
