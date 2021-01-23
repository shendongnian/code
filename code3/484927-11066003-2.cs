    Imports System.Runtime.InteropServices
    
    Public Module KeyboardHook
        <DllImport("user32.dll")>
        Public Function SetWindowsHookEx(ByVal idHook As Integer, ByVal HookProc As KBDLLHookProc, ByVal hInstance As IntPtr, ByVal wParam As Integer) As IntPtr
    
        End Function
    
        <DllImport("user32.dll")>
        Public Function CallNextHookEx(ByVal idHook As IntPtr, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    
        End Function
    
        <DllImport("user32.dll")>
        Public Function UnhookWindowsHookEx(ByVal idHook As IntPtr) As Boolean
    
        End Function
    
        <StructLayout(LayoutKind.Sequential)>
        Public Structure KBDLLHOOKSTRUCT
            Public vkCode As UInteger
            Public scanCode As UInteger
            Public flags As KBDLLHOOKSTRUCTFlags
            Public time As UInteger
            Public dwExtraInfo As UIntPtr
        End Structure
    
        <Flags()>
        Public Enum KBDLLHOOKSTRUCTFlags As UInteger
            LLKHF_EXTENDED = &H1
            LLKHF_INJECTED = &H10
            LLKHF_ALTDOWN = &H20
            LLKHF_UP = &H80
        End Enum
    
        Public Const WH_KEYBOARD_LL As Integer = 13
        Public Const HC_ACTION As Integer = 0
        Public Const WM_KEYDOWN As Integer = &H100
        Public Const WM_KEYUP As Integer = &H101
        Public Const WM_SYSKEYDOWN As Integer = &H104
        Public Const WM_SYSKEYUP As Integer = &H105
    
        Public Delegate Function KBDLLHookProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Module
