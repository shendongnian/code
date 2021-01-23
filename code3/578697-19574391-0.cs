    Imports System.Runtime.InteropServices
    Public Class Form1
    
        'From http://www.pinvoke.net/default.aspx/winmm/MMRESULT.html
        Private Enum MMRESULT
            MMSYSERR_NOERROR = 0
            MMSYSERR_ERROR = 1
            MMSYSERR_BADDEVICEID = 2
            MMSYSERR_NOTENABLED = 3
            MMSYSERR_ALLOCATED = 4
            MMSYSERR_INVALHANDLE = 5
            MMSYSERR_NODRIVER = 6
            MMSYSERR_NOMEM = 7
            MMSYSERR_NOTSUPPORTED = 8
            MMSYSERR_BADERRNUM = 9
            MMSYSERR_INVALFLAG = 10
            MMSYSERR_INVALPARAM = 11
            MMSYSERR_HANDLEBUSY = 12
            MMSYSERR_INVALIDALIAS = 13
            MMSYSERR_BADDB = 14
            MMSYSERR_KEYNOTFOUND = 15
            MMSYSERR_READERROR = 16
            MMSYSERR_WRITEERROR = 17
            MMSYSERR_DELETEERROR = 18
            MMSYSERR_VALNOTFOUND = 19
            MMSYSERR_NODRIVERCB = 20
            WAVERR_BADFORMAT = 32
            WAVERR_STILLPLAYING = 33
            WAVERR_UNPREPARED = 34
        End Enum
    
        'http://msdn.microsoft.com/en-us/library/windows/desktop/dd757625(v=vs.85).aspx
        <StructLayout(LayoutKind.Sequential)>
        Public Structure TIMECAPS
            Public periodMin As UInteger
            Public periodMax As UInteger
        End Structure
    
        'http://msdn.microsoft.com/en-us/library/windows/desktop/dd757627(v=vs.85).aspx
        <DllImport("winmm.dll")>
        Private Shared Function timeGetDevCaps(ByRef ptc As TIMECAPS, ByVal cbtc As UInteger) As MMRESULT
        End Function
    
        'http://msdn.microsoft.com/en-us/library/windows/desktop/dd757624(v=vs.85).aspx
        <DllImport("winmm.dll")>
        Private Shared Function timeBeginPeriod(ByVal uPeriod As UInteger) As MMRESULT
        End Function
    
        'http://msdn.microsoft.com/en-us/library/windows/desktop/dd757626(v=vs.85).aspx
        <DllImport("winmm.dll")>
        Private Shared Function timeEndPeriod(ByVal uPeriod As UInteger) As MMRESULT
        End Function
    
        'http://msdn.microsoft.com/en-us/library/windows/desktop/ff728861(v=vs.85).aspx
        Private Delegate Sub TIMECALLBACK(ByVal uTimerID As UInteger, _
                                      ByVal uMsg As UInteger, _
                                      ByVal dwUser As IntPtr, _
                                      ByVal dw1 As IntPtr, _
                                      ByVal dw2 As IntPtr)
    
        'Straight from C:\Program Files (x86)\Microsoft SDKs\Windows\v7.1A\Include\MMSystem.h
        'fuEvent below is a combination of these flags.
        Private Const TIME_ONESHOT As UInteger = 0
        Private Const TIME_PERIODIC As UInteger = 1
        Private Const TIME_CALLBACK_FUNCTION As UInteger = 0
        Private Const TIME_CALLBACK_EVENT_SET As UInteger = &H10
        Private Const TIME_CALLBACK_EVENT_PULSE As UInteger = &H20
        Private Const TIME_KILL_SYNCHRONOUS As UInteger = &H100
    
        'http://msdn.microsoft.com/en-us/library/windows/desktop/dd757634(v=vs.85).aspx
        'Documentation is self-contradicting. The return value is Uinteger, I'm guessing.
        '"Returns an identifier for the timer event if successful or an error otherwise. 
        'This function returns NULL if it fails and the timer event was not created."
        <DllImport("winmm.dll")>
        Private Shared Function timeSetEvent(ByVal uDelay As UInteger, _
                                             ByVal uResolution As UInteger, _
                                             ByVal TimeProc As TIMECALLBACK, _
                                             ByVal dwUser As IntPtr, _
                                             ByVal fuEvent As UInteger) As UInteger
        End Function
    
        'http://msdn.microsoft.com/en-us/library/windows/desktop/dd757630(v=vs.85).aspx
        <DllImport("winmm.dll")>
        Private Shared Function timeKillEvent(ByVal uTimerID As UInteger) As MMRESULT
        End Function
    
        Private lblRate As New Windows.Forms.Label
        Private WithEvents tmrUI As New Windows.Forms.Timer
        Private WithEvents tmrWorkThreading As New System.Threading.Timer(AddressOf TimerTick)
        Private WithEvents tmrWorkTimers As New System.Timers.Timer
        Private WithEvents tmrWorkForm As New Windows.Forms.Timer
    
        Public Sub New()
            lblRate.AutoSize = True
            Me.Controls.Add(lblRate)
    
            InitializeComponent()
        End Sub
    
        Private Capability As New TIMECAPS
        Private StartTime As DateTime = DateTime.Now
    
        Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            timeKillEvent(dwUser)
            timeEndPeriod(Capability.periodMin)
        End Sub
    
        Private dwUser As UInteger = 0
        Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) _
            Handles MyBase.Load
    
            Dim Result As MMRESULT
    
            'Get the min and max period
            Result = timeGetDevCaps(Capability, Marshal.SizeOf(Capability))
            If Result <> MMRESULT.MMSYSERR_NOERROR Then
                MsgBox("timeGetDevCaps returned " + Result.ToString)
                Exit Sub
            End If
    
            'Set to the minimum period.
            Result = timeBeginPeriod(Capability.periodMin)
            If Result <> MMRESULT.MMSYSERR_NOERROR Then
                MsgBox("timeBeginPeriod returned " + Result.ToString)
                Exit Sub
            End If
    
            Dim uTimerID As UInteger
            uTimerID = timeSetEvent(Capability.periodMin, Capability.periodMin, _
                         New TIMECALLBACK(AddressOf MMCallBack), dwUser, _
                         TIME_PERIODIC Or TIME_CALLBACK_FUNCTION Or TIME_KILL_SYNCHRONOUS)
            If uTimerID = 0 Then
                MsgBox("timeSetEvent not successful.")
                Exit Sub
            End If
    
            tmrWorkThreading.Change(0, 1)
    
            tmrWorkTimers.Interval = 1
            tmrWorkTimers.Enabled = True
    
            tmrWorkForm.Interval = 1
            tmrWorkForm.Enabled = True
    
            tmrUI.Interval = 100
            tmrUI.Enabled = True
        End Sub
    
        Private CounterThreading As Integer = 0
        Private CounterTimers As Integer = 0
        Private CounterForms As Integer = 0
        Private CounterMM As Integer = 0
    
        Private ReadOnly TimersLock As New Object
        Private Sub tmrWorkTimers_Elapsed(sender As Object, e As System.Timers.ElapsedEventArgs) _
            Handles tmrWorkTimers.Elapsed
            SyncLock TimersLock
                CounterTimers += 1
            End SyncLock
        End Sub
    
        Private ReadOnly ThreadingLock As New Object
        Private Sub TimerTick()
            SyncLock ThreadingLock
                CounterThreading += 1
            End SyncLock
        End Sub
    
        Private ReadOnly MMLock As New Object
        Private Sub MMCallBack(ByVal uTimerID As UInteger, _
                                      ByVal uMsg As UInteger, _
                                      ByVal dwUser As IntPtr, _
                                      ByVal dw1 As IntPtr, _
                                      ByVal dw2 As IntPtr)
            SyncLock MMLock
                CounterMM += 1
            End SyncLock
        End Sub
    
        Private ReadOnly FormLock As New Object
        Private Sub tmrWorkForm_Tick(sender As Object, e As System.EventArgs) Handles tmrWorkForm.Tick
            SyncLock FormLock
                CounterForms += 1
            End SyncLock
        End Sub
    
        Private Sub tmrUI_Tick(sender As Object, e As System.EventArgs) _
        Handles tmrUI.Tick
            Dim Secs As Integer = (DateTime.Now - StartTime).TotalSeconds
            If Secs > 0 Then
                Dim TheText As String = ""
                TheText += "System.Threading.Timer " + (CounterThreading / Secs).ToString("#,##0.0") + "Hz" + vbCrLf
                TheText += "System.Timers.Timer " + (CounterTimers / Secs).ToString("#,##0.0") + "Hz" + vbCrLf
                TheText += "Windows.Forms.Timer " + (CounterForms / Secs).ToString("#,##0.0") + "Hz" + vbCrLf
                TheText += "Multimedia Timer " + (CounterMM / Secs).ToString("#,##0.0") + "Hz"
                lblRate.Text = TheText
            End If
        End Sub
    
    End Class
