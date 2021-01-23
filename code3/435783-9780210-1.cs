        Loaded += Function(_, __) Do
        Microsoft.Phone.Shell.PhoneApplicationService.Current.ApplicationIdleDetectionMode = Microsoft.Phone.Shell.IdleDetectionMode.Disabled
        cam = New VideoCamera()
        cam.Initialized += Function(___, ____) Do
            cam.LampEnabled = True
            cam.StartRecording()
        End Function
        vCam.SetSource(cam)
        New Thread(Function() Do
            Try
                Dim isf = IsolatedStorageFile.GetUserStoreForApplication()
                Dim files = isf.GetFileNames()
                For Each file As var In files
                    Debug.WriteLine("Deleting... " + file)
                    isf.DeleteFile(file)
                Next
            Catch ex As Exception
                Debug.WriteLine("Error cleaning up isolated storage: " + ex)
            End Try
        End Function).Start()
    End Function
