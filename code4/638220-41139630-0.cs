    Private Enum ScrollViewTrackingMasterSv
        Header = 1
        ListView = 2
        None = 0
    End Enum
    Private ScrollViewTrackingMaster As ScrollViewTrackingMasterSv
    Private DispatchTimerForSvTracking As DispatcherTimer    
    Private Sub DispatchTimerForSvTrackingSub(sender As Object, e As Object)
        ScrollViewTrackingMaster = ScrollViewTrackingMasterSv.None
        DispatchTimerForSvTracking.Stop()
    End Sub
    Private Sub svLvTracking(sender As Object, e As ScrollViewerViewChangedEventArgs, ByRef inMastScrollViewer As ScrollViewer)
        Dim tempHorOffset As Double
        Dim tempVerOffset As Double
        Dim tempZoomFactor As Single
        Dim tempSvMaster As New ScrollViewer
        Dim tempSvSlave As New ScrollViewer
        Select Case inMastScrollViewer.Name
            Case svLvMainHeader.Name
                Select Case ScrollViewTrackingMaster
                    Case ScrollViewTrackingMasterSv.Header
                        tempSvMaster = svLvMainHeader
                        tempSvSlave = svLvMain
                        tempHorOffset = tempSvMaster.HorizontalOffset
                        tempVerOffset = tempSvMaster.VerticalOffset
                        tempZoomFactor = tempSvMaster.ZoomFactor
                        tempSvSlave.ChangeView(tempHorOffset, tempVerOffset, tempZoomFactor)
                        If DispatchTimerForSvTracking.IsEnabled Then
                            DispatchTimerForSvTracking.Stop()
                            DispatchTimerForSvTracking.Start()
                        End If
                    Case ScrollViewTrackingMasterSv.ListView
                    Case ScrollViewTrackingMasterSv.None
                        tempSvMaster = svLvMainHeader
                        tempSvSlave = svLvMain
                        ScrollViewTrackingMaster = ScrollViewTrackingMasterSv.Header
                        DispatchTimerForSvTracking = New DispatcherTimer()
                        AddHandler DispatchTimerForSvTracking.Tick, AddressOf DispatchTimerForSvTrackingSub
                        DispatchTimerForSvTracking.Interval = New TimeSpan(0, 0, 0, 0, 500)
                        DispatchTimerForSvTracking.Start()
                        tempHorOffset = tempSvMaster.HorizontalOffset
                        tempVerOffset = tempSvMaster.VerticalOffset
                        tempZoomFactor = tempSvMaster.ZoomFactor
                        tempSvSlave.ChangeView(tempHorOffset, tempVerOffset, tempZoomFactor)
                End Select
            Case svLvMain.Name
                Select Case ScrollViewTrackingMaster
                    Case ScrollViewTrackingMasterSv.Header
                    Case ScrollViewTrackingMasterSv.ListView
                        tempSvMaster = svLvMain
                        tempSvSlave = svLvMainHeader
                        tempHorOffset = tempSvMaster.HorizontalOffset
                        tempVerOffset = tempSvMaster.VerticalOffset
                        tempZoomFactor = tempSvMaster.ZoomFactor
                        tempSvSlave.ChangeView(tempHorOffset, tempVerOffset, tempZoomFactor)
                        If DispatchTimerForSvTracking.IsEnabled Then
                            DispatchTimerForSvTracking.Stop()
                            DispatchTimerForSvTracking.Start()
                        End If
                    Case ScrollViewTrackingMasterSv.None
                        tempSvMaster = svLvMain
                        tempSvSlave = svLvMainHeader
                        ScrollViewTrackingMaster = ScrollViewTrackingMasterSv.ListView
                        DispatchTimerForSvTracking = New DispatcherTimer()
                        AddHandler DispatchTimerForSvTracking.Tick, AddressOf DispatchTimerForSvTrackingSub
                        DispatchTimerForSvTracking.Interval = New TimeSpan(0, 0, 0, 0, 500)
                        DispatchTimerForSvTracking.Start()
                        tempHorOffset = tempSvMaster.HorizontalOffset
                        tempVerOffset = tempSvMaster.VerticalOffset
                        tempZoomFactor = tempSvMaster.ZoomFactor
                        tempSvSlave.ChangeView(tempHorOffset, tempVerOffset, tempZoomFactor)
                End Select
            Case Else
                Exit Sub
        End Select
    End Sub
    Private Sub svLvMainHeader_ViewChanged(sender As Object, e As ScrollViewerViewChangedEventArgs) Handles svLvMainHeader.ViewChanged
        Call svLvTracking(sender, e, svLvMainHeader)
    End Sub
    Private Sub svLvMain_ViewChanged(sender As Object, e As ScrollViewerViewChangedEventArgs) Handles svLvMain.ViewChanged
        Call svLvTracking(sender, e, svLvMain)
    End Sub
