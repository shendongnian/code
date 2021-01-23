    Imports System
    Imports System.Text
    Imports System.Drawing
    Imports System.IO.Ports
    Imports System.Windows.Forms
    Public Class CommManager
    Public Enum TransmissionType
        Text
        Hex
    End Enum
    Public Enum MessageType
        Incoming
        Outgoing
        Normal
        Warning
        [Error]
    End Enum
    Private _baudRate As String = String.Empty
    Private _parity As String = String.Empty
    Private _stopBits As String = String.Empty
    Private _dataBits As String = String.Empty
    Private _portName As String = String.Empty
    Private _transType As TransmissionType
    Private _displayWindow As RichTextBox
    Private _msg As String
    Private _type As MessageType
    Private MessageColor As Color() = {Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red}
    Private comPort As New SerialPort()
    Private write As Boolean = True
    Public Property BaudRate() As String
        Get
            Return _baudRate
        End Get
        Set(ByVal value As String)
            _baudRate = value
        End Set
    End Property
    Public Property Parity() As String
        Get
            Return _parity
        End Get
        Set(ByVal value As String)
            _parity = value
        End Set
    End Property
    Public Property StopBits() As String
        Get
            Return _stopBits
        End Get
        Set(ByVal value As String)
            _stopBits = value
        End Set
    End Property
    Public Property DataBits() As String
        Get
            Return _dataBits
        End Get
        Set(ByVal value As String)
            _dataBits = value
        End Set
    End Property
    Public Property PortName() As String
        Get
            Return _portName
        End Get
        Set(ByVal value As String)
            _portName = value
        End Set
    End Property
    Public Property CurrentTransmissionType() As TransmissionType
        Get
            Return _transType
        End Get
        Set(ByVal value As TransmissionType)
            _transType = value
        End Set
    End Property
    Public Property DisplayWindow() As RichTextBox
        Get
            Return _displayWindow
        End Get
        Set(ByVal value As RichTextBox)
            _displayWindow = value
        End Set
    End Property
    Public Property Message() As String
        Get
            Return _msg
        End Get
        Set(ByVal value As String)
            _msg = value
        End Set
    End Property
    Public Property Type() As MessageType
        Get
            Return _type
        End Get
        Set(ByVal value As MessageType)
            _type = value
        End Set
    End Property
    Public Sub New(ByVal baud As String, ByVal par As String, ByVal sBits As String, ByVal dBits As String, ByVal name As String, ByVal rtb As RichTextBox)
        _baudRate = baud
        _parity = par
        _stopBits = sBits
        _dataBits = dBits
        _portName = name
        _displayWindow = rtb
        AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
    End Sub
    Public Sub New()
        _baudRate = String.Empty
        _parity = String.Empty
        _stopBits = String.Empty
        _dataBits = String.Empty
        _portName = "COM1"
        _displayWindow = Nothing
        AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
    End Sub
    Public Sub WriteData(ByVal msg As String)
        Select Case CurrentTransmissionType
            Case TransmissionType.Text
                If Not (comPort.IsOpen = True) Then
                    comPort.Open()
                End If
                comPort.Write(msg)
                _type = MessageType.Outgoing
                _msg = msg + "" + Environment.NewLine + ""
                DisplayData(_type, _msg)
                Exit Select
            Case TransmissionType.Hex
                Try
                    'convert the message to byte array
                    Dim newMsg As Byte() = HexToByte(msg)
                    If Not write Then
                        DisplayData(_type, _msg)
                        Exit Sub
                    End If
                    'send the message to the port
                    comPort.Write(newMsg, 0, newMsg.Length)
                    'convert back to hex and display
                    _type = MessageType.Outgoing
                    _msg = ByteToHex(newMsg) + "" + Environment.NewLine + ""
                    DisplayData(_type, _msg)
                Catch ex As FormatException
                    'display error message
                    _type = MessageType.Error
                    _msg = ex.Message + "" + Environment.NewLine + ""
                    DisplayData(_type, _msg)
                Finally
                    _displayWindow.SelectAll()
                End Try
                Exit Select
            Case Else
                If Not (comPort.IsOpen = True) Then
                    comPort.Open()
                End If
                comPort.Write(msg)
                _type = MessageType.Outgoing
                _msg = msg + "" + Environment.NewLine + ""
                DisplayData(MessageType.Outgoing, msg + "" + Environment.NewLine + "")
                Exit Select
        End Select
    End Sub
    Private Function HexToByte(ByVal msg As String) As Byte()
        If msg.Length Mod 2 = 0 Then
            _msg = msg
            _msg = msg.Replace(" ", "")
            Dim comBuffer As Byte() = New Byte(_msg.Length / 2 - 1) {}
            For i As Integer = 0 To _msg.Length - 1 Step 2
                comBuffer(i / 2) = CByte(Convert.ToByte(_msg.Substring(i, 2), 16))
            Next
            write = True
            Return comBuffer
        Else
            _msg = "Invalid format"
            _type = MessageType.Error
            write = False
            Return Nothing
        End If
    End Function
    Private Function ByteToHex(ByVal comByte As Byte()) As String
        Dim builder As New StringBuilder(comByte.Length * 3)
        For Each data As Byte In comByte
            builder.Append(Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c))
        Next
        Return builder.ToString().ToUpper()
    End Function
    <STAThread()> _
    Private Sub DisplayData(ByVal type As MessageType, ByVal msg As String)
        _displayWindow.Invoke(New EventHandler(AddressOf DoDisplay))
    End Sub
    Public Function OpenPort() As Boolean
        Try
            If comPort.IsOpen = True Then
                comPort.Close()
            End If
            comPort.BaudRate = Integer.Parse(_baudRate)
            comPort.DataBits = Integer.Parse(_dataBits)
            comPort.StopBits = DirectCast([Enum].Parse(GetType(StopBits), _stopBits), StopBits)
            comPort.Parity = DirectCast([Enum].Parse(GetType(Parity), _parity), Parity)
            comPort.PortName = _portName
            comPort.Open()
            _type = MessageType.Normal
            _msg = "Port opened at " + DateTime.Now + "" + Environment.NewLine + ""
            DisplayData(_type, _msg)
            Return True
        Catch ex As Exception
            DisplayData(MessageType.[Error], ex.Message)
            Return False
        End Try
    End Function
    Public Sub ClosePort()
        If comPort.IsOpen Then
            _msg = "Port closed at " + DateTime.Now + "" + Environment.NewLine + ""
            _type = MessageType.Normal
            DisplayData(_type, _msg)
            comPort.Close()
        End If
    End Sub
    Public Sub SetParityValues(ByVal obj As Object)
        For Each str As String In [Enum].GetNames(GetType(Parity))
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
    Public Sub SetStopBitValues(ByVal obj As Object)
        For Each str As String In [Enum].GetNames(GetType(StopBits))
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
    Public Sub SetPortNameValues(ByVal obj As Object)
        For Each str As String In SerialPort.GetPortNames()
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Select Case CurrentTransmissionType
            Case TransmissionType.Text
                Dim msg As String = comPort.ReadExisting()
                _type = MessageType.Incoming
                _msg = msg
                DisplayData(MessageType.Incoming, msg + "" + Environment.NewLine + "")
                Exit Select
            Case TransmissionType.Hex
                Dim bytes As Integer = comPort.BytesToRead
                Dim comBuffer As Byte() = New Byte(bytes - 1) {}
                comPort.Read(comBuffer, 0, bytes)
                _type = MessageType.Incoming
                _msg = ByteToHex(comBuffer) + "" + Environment.NewLine + ""
                DisplayData(MessageType.Incoming, ByteToHex(comBuffer) + "" + Environment.NewLine + "")
                Exit Select
            Case Else
                Dim str As String = comPort.ReadExisting()
                _type = MessageType.Incoming
                _msg = str + "" + Environment.NewLine + ""
                DisplayData(MessageType.Incoming, str + "" + Environment.NewLine + "")
                Exit Select
        End Select
    End Sub
    Private Sub DoDisplay(ByVal sender As Object, ByVal e As EventArgs)
        _displayWindow.SelectedText = String.Empty
        _displayWindow.SelectionFont = New Font(_displayWindow.SelectionFont, FontStyle.Bold)
        _displayWindow.SelectionColor = MessageColor(CType(_type, Integer))
        _displayWindow.AppendText(_msg)
        _displayWindow.ScrollToCaret()
        End Sub
        End Class
