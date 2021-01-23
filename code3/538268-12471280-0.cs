    Private Declare Function WTSRegisterSessionNotification Lib "Wtsapi32" (ByVal hWnd As IntPtr, ByVal THISSESS As Integer) As Integer
        Private Declare Function WTSUnRegisterSessionNotification Lib "Wtsapi32" (ByVal hWnd As IntPtr) As Integer
    
        Private Const NOTIFY_FOR_ALL_SESSIONS As Integer = 1
        Private Const NOTIFY_FOR_THIS_SESSION As Integer = 0
        Private Const WM_WTSSESSION_CHANGE As Integer = &H2B1
    
        
    
        Private Enum WTS
            CONSOLE_CONNECT = 1
            CONSOLE_DISCONNECT = 2
            REMOTE_CONNECT = 3
            REMOTE_DISCONNECT = 4
            SESSION_LOGON = 5
            SESSION_LOGOFF = 6
            SESSION_LOCK = 7
            SESSION_UNLOCK = 8
            SESSION_REMOTE_CONTROL = 9
        End Enum
        Shared FileName As String
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Hide()
            WTSRegisterSessionNotification(Me.Handle, NOTIFY_FOR_ALL_SESSIONS)
            Timer1.Start()
            Me.Hide()
            FileName = Application.StartupPath + "/Data/TimeSheet_" + DateTime.Today.ToString("dd-MMM-yyyy") + ".txt"
            System.IO.File.Create(FileName)
        End Sub
    
        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            Select Case m.Msg
                Case WM_WTSSESSION_CHANGE
                    Select Case m.WParam.ToInt32
                        Case WTS.CONSOLE_CONNECT
                            'MessageBox.Show("A session was connected to the console session.")
                            Timer1.Start()
                            System.IO.File.AppendAllText(FileName, "IN - " + lblTime.Text)
                        Case WTS.CONSOLE_DISCONNECT
                            'MessageBox.Show("A session was disconnected from the console session.")
                            System.IO.File.AppendAllText(FileName, "OUT - " + lblTime.Text + vbCrLf)
                            Timer1.Stop()
                        Case WTS.REMOTE_CONNECT
                            'MessageBox.Show("A session was connected to the remote session.")
                        Case WTS.REMOTE_DISCONNECT
                            'MessageBox.Show("A session was disconnected from the remote session.")
                        Case WTS.SESSION_LOGON
                            Timer1.Start()
                            System.IO.File.AppendAllText(FileName, "IN - " + lblTime.Text)
                            'MessageBox.Show("A user has logged on to the session.")
                        Case WTS.SESSION_LOGOFF
                            'MessageBox.Show("A user has logged off the session.")
                            System.IO.File.AppendAllText(FileName, "OUT - " + lblTime.Text + vbCrLf)
                            Timer1.Stop()
                        Case WTS.SESSION_LOCK
                            'MessageBox.Show("A session has been locked.")
                            System.IO.File.AppendAllText(FileName, "OUT - " + lblTime.Text + vbCrLf)
                            Timer1.Stop()
                        Case WTS.SESSION_UNLOCK
                            'MessageBox.Show("A session has been unlocked.")
                            Timer1.Start()
                            System.IO.File.AppendAllText(FileName, "IN - " + lblTime.Text)
                            If m_clsBalloonEvents Is Nothing Then
                                'allow our ballon class to create the event class for us, hooking into the notify icon that will 
                                'be associated with the balloons...
                                m_clsBalloonEvents = Balloon.HookBalloonEvents(niMain)
                                'add handlers for the events that we are concerned with in this application...
                                AddHandler m_clsBalloonEvents.BallonClicked, AddressOf BalloonClicked
                                AddHandler m_clsBalloonEvents.BallonHidden, AddressOf BalloonHidden
                            End If
                            Balloon.DisplayBalloon(niMain, "Today's Time", lblTime.Text, CType(IIf(False, Balloon.BalloonMessageTypes.Error, Balloon.BalloonMessageTypes.Info), Balloon.BalloonMessageTypes))
                        Case WTS.SESSION_REMOTE_CONTROL
                            MessageBox.Show("A session has changed its remote controlled status. To determine the status, call GetSystemMetrics and check the SM_REMOTECONTROL metric.")
                    End Select
    
            End Select
    
            MyBase.WndProc(m)
        End Sub
