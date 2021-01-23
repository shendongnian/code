    Private hook As IntPtr
    Private isVisible As Boolean = False
    Private keyHookDelegate As New KBDLLHookProc(AddressOf Me.KeyHook)
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set the key hook:
        hook = SetWindowsHookEx(KeyboardHook.WH_KEYBOARD_LL, Me.keyHookDelegate, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()(0)), 0)
        If hook = IntPtr.Zero Then
            MessageBox.Show("Failed to set global key hook.", "Key Hook Set Failiure", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New ApplicationException("Failed to set key hook.")
        End If
    End Sub
    Private Function KeyHook(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
        If nCode = KeyboardHook.HC_ACTION Then
            Dim p As Integer = wParam.ToInt32()
            If p = WM_KEYDOWN OrElse p = WM_SYSKEYDOWN Then
                Dim keyCode As Keys = CType(CType(Marshal.PtrToStructure(lParam, GetType(KBDLLHOOKSTRUCT)), KBDLLHOOKSTRUCT).vkCode, Keys) ' This gets the key that was pressed.
                    'Cancel it!
                    Return 1
                End If
            End If
        End If
        Return KeyboardHook.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
    End Function
    Protected Overrides Sub Finalize()
        Try
            'Remove the key hook:
            If hook <> IntPtr.Zero Then KeyboardHook.UnhookWindowsHookEx(hook)
        Finally
            MyBase.Finalize()
        End Try
    End Sub
