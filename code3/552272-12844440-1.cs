    Private Sub InstallUpdates()
        Dim info As UpdateCheckInfo = Nothing
        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                (You may want to log here)
                Return
            Catch ioe As InvalidOperationException
                (You may want to log here)
                Return
            End Try
            If (info.UpdateAvailable) Then
                Try
                    AD.Update()
                    Application.Restart()
                Catch dde As DeploymentDownloadException
                    (You may want to log here)
                    Return
                End Try
            End If
        End If
    End Sub
