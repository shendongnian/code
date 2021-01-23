    Public Class Form1
    
      Private Resolution As New ResolutionChanger
      Private OldWidth As UInteger
      Private OldHeight As UInteger
    
      Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Resolution.SetResolution(OldWidth, OldHeight)
      End Sub
      Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OldHeight = CUInt(Screen.PrimaryScreen.Bounds.Height)
        OldWidth = CUInt(Screen.PrimaryScreen.Bounds.Width)
        Select Case Resolution.SetResolution(800, 600)
          Case ResolutionChanger.ChangeResult.Success
            MsgBox("The Resolution was changed", MsgBoxStyle.OkOnly)
          Case ResolutionChanger.ChangeResult.Restart
            MsgBox("Restart your system to activate the new resolution setting", MsgBoxStyle.OkOnly)
          Case ResolutionChanger.ChangeResult.Fail
            MsgBox("The resolution couldn't be changed", MsgBoxStyle.OkOnly)
          Case ResolutionChanger.ChangeResult.ResolutionNotSupported
            MsgBox("The requested resolution is not supported by your system", MsgBoxStyle.OkOnly)
        End Select
      End Sub
    
    End Class
    '
    '========== RESOLUTION CHANGER ===============================
    '
    '
    Class ResolutionChanger
      Public Enum ChangeResult
        Success
        Restart
        Fail
        ResolutionNotSupported
      End Enum
    
      Public Function SetResolution(ByVal Width As UInteger, ByVal Height As UInteger) As ChangeResult
        Dim DevMode As New DEVMODEA
        If User_32.EnumDisplaySettingsA(Screen.PrimaryScreen.DeviceName, ENUM_CURRENT_SETTINGS, DevMode) Then
          DevMode.dmPelsWidth = Width
          DevMode.dmPelsHeight = Height
          Dim ReturnValue = User_32.ChangeDisplaySettingsA(DevMode, CDS_TEST)
          If ReturnValue = DISP_CHANGE_FAILED Then
            'The Requested resolution is not supported by the system
            Return ChangeResult.ResolutionNotSupported
          Else
            ReturnValue = User_32.ChangeDisplaySettingsA(DevMode, CDS_UPDATEREGISTRY)
            Select Case ReturnValue
              Case DISP_CHANGE_RESTART
                'The resolution cannot be change dynamically on every system
                'Windows 9x and some Laptop (XP,Vista,Windows7) have to reboot.
                Return ChangeResult.Restart
              Case DISP_CHANGE_SUCCESSFUL
                'Resolution was changed
                'This is not an assurance that the new resolution will render 
                'proprely on every system. It only means that the registery was
                'updated succesfuly and that the driver have not return any
                'error
                Return ChangeResult.Success
              Case Else
                'An error has caused the resolution not to be changed
                Return ChangeResult.Fail
            End Select
          End If
        End If
      End Function
      '
      '============Region Interop ==============================================
      '
      '
      Private Const ENUM_CURRENT_SETTINGS As Integer = -1
      Private Const CDS_UPDATEREGISTRY As Integer = 1
      Private Const CDS_TEST As Integer = 2
      Private Const DISP_CHANGE_SUCCESSFUL As Integer = 0
      Private Const DISP_CHANGE_RESTART As Integer = 1
      Private Const DISP_CHANGE_FAILED As Integer = -1
    
      <System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)> _
      Public Structure DEVMODEA
        'BYTE[32]
        <System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32, ArraySubType:=System.Runtime.InteropServices.UnmanagedType.I1)> _
        Public dmDeviceName() As Byte
        Public dmSpecVersion As UShort
        Public dmDriverVersion As UShort
        Public dmSize As UShort
        Public dmDriverExtra As UShort
        Public dmFields As UInteger
        Public Union1 As Anonymous_2338c0fc_03a3_4514_b536_fb9bb5df14c5
        Public dmColor As Short
        Public dmDuplex As Short
        Public dmYResolution As Short
        Public dmTTOption As Short
        Public dmCollate As Short
        <System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32, ArraySubType:=System.Runtime.InteropServices.UnmanagedType.I1)> _
        Public dmFormName() As Byte
        Public dmLogPixels As UShort
        Public dmBitsPerPel As UInteger
        Public dmPelsWidth As UInteger
        Public dmPelsHeight As UInteger
        Public Union2 As Anonymous_7557e508_845c_4777_b9f2_a1496c1c7b21
        Public dmDisplayFrequency As UInteger
        Public dmICMMethod As UInteger
        Public dmICMIntent As UInteger
        Public dmMediaType As UInteger
        Public dmDitherType As UInteger
        Public dmReserved1 As UInteger
        Public dmReserved2 As UInteger
        Public dmPanningWidth As UInteger
        Public dmPanningHeight As UInteger
      End Structure
    
      <System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)> _
      Public Structure Anonymous_2338c0fc_03a3_4514_b536_fb9bb5df14c5
        <System.Runtime.InteropServices.FieldOffsetAttribute(0)> _
        Public Struct1 As Anonymous_a67d541d_da92_408e_8852_89977e56cead
        <System.Runtime.InteropServices.FieldOffsetAttribute(0)> _
        Public Struct2 As Anonymous_d973d7e7_ad4c_4155_86fe_6d2b51ab5f04
      End Structure
    
      <System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)> _
      Public Structure Anonymous_7557e508_845c_4777_b9f2_a1496c1c7b21
        <System.Runtime.InteropServices.FieldOffsetAttribute(0)> _
        Public dmDisplayFlags As UInteger
        <System.Runtime.InteropServices.FieldOffsetAttribute(0)> _
        Public dmNup As UInteger
      End Structure
    
      <System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)> _
      Public Structure Anonymous_a67d541d_da92_408e_8852_89977e56cead
        Public dmOrientation As Short
        Public dmPaperSize As Short
        Public dmPaperLength As Short
        Public dmPaperWidth As Short
        Public dmScale As Short
        Public dmCopies As Short
        Public dmDefaultSource As Short
        Public dmPrintQuality As Short
      End Structure
    
      <System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)> _
      Public Structure Anonymous_d973d7e7_ad4c_4155_86fe_6d2b51ab5f04
        Public dmPosition As POINTL
        Public dmDisplayOrientation As UInteger
        Public dmDisplayFixedOutput As UInteger
      End Structure
    
      <System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)> _
      Public Structure POINTL
        Public x As Integer
        Public y As Integer
      End Structure
    
      Partial Public Class User_32
        <System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint:="EnumDisplaySettingsA")> _
        Public Shared Function EnumDisplaySettingsA(<System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)> ByVal lpszDeviceName As String, ByVal iModeNum As Integer, <System.Runtime.InteropServices.OutAttribute()> ByRef lpDevMode As DEVMODEA) As <System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)> Boolean
        End Function
    
        <System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint:="ChangeDisplaySettingsA")> _
        Public Shared Function ChangeDisplaySettingsA(<System.Runtime.InteropServices.OutAttribute()> ByRef lpDevMode As DEVMODEA, ByVal dwFlags As UInteger) As Integer
        End Function
      End Class
    
    End Class
