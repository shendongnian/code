    Imports System
    Imports System.Runtime.InteropServices
    Imports System.ComponentModel
    Imports System.Net
    Imports System.Runtime.CompilerServices
    Module Program
    ' The max length of physical address.
    Const MAXLEN_PHYSADDR As Integer = 8
    ' Define the MIB_IPNETROW structure.
    <StructLayout(LayoutKind.Sequential)> _
    Structure MIB_IPNETROW
        <MarshalAs(UnmanagedType.U4)> _
        Public dwIndex As Integer
        <MarshalAs(UnmanagedType.U4)> _
        Public dwPhysAddrLen As Integer
        <MarshalAs(UnmanagedType.U1)> _
        Public mac0 As Byte
        <MarshalAs(UnmanagedType.U1)> _
        Public mac1 As Byte
        <MarshalAs(UnmanagedType.U1)> _
        Public mac2 As Byte
        <MarshalAs(UnmanagedType.U1)> _
        Public mac3 As Byte
        <MarshalAs(UnmanagedType.U1)> _
        Public mac4 As Byte
        <MarshalAs(UnmanagedType.U1)> _
        Public mac5 As Byte
        <MarshalAs(UnmanagedType.U1)> _
        Public mac6 As Byte
        <MarshalAs(UnmanagedType.U1)> _
        Public mac7 As Byte
        <MarshalAs(UnmanagedType.U4)> _
        Public dwAddr As Integer
        <MarshalAs(UnmanagedType.U4)> _
        Public dwType As Integer
    End Structure
    ' Declare the GetIpNetTable function.
    Declare Function GetIpNetTable Lib "IpHlpApi.dll" (
        ByVal pIpNetTable As IntPtr,
        <MarshalAs(UnmanagedType.U4)>
        ByRef pdwSize As Integer,
        ByVal bOrder As Boolean) As <MarshalAs(UnmanagedType.U4)> Integer
    ' The insufficient buffer error.
    Const ERROR_INSUFFICIENT_BUFFER As Integer = 122
    Sub Main(ByVal args() As String)
        ' The number of bytes needed.
        Dim bytesNeeded = 0
        ' The result from the API call.
        Dim result = GetIpNetTable(IntPtr.Zero, bytesNeeded, False)
        ' Call the function, expecting an insufficient buffer.
        If result <> ERROR_INSUFFICIENT_BUFFER Then
            ' Throw an exception.
            Throw New Win32Exception(result)
        End If
        ' Allocate the memory.
        Dim buffer = Marshal.AllocCoTaskMem(bytesNeeded)
        Try
            ' Make the call again. If it did not succeed, then
            ' raise an error.
            result = GetIpNetTable(buffer, bytesNeeded, False)
            ' If the result is not 0 (no error), then throw an exception.
            If result <> 0 Then _
                Throw New Win32Exception(result)
            ' Now we have the buffer, we have to marshal it. We can read
            ' the first 4 bytes to get the length of the buffer.
            Dim entries = Marshal.ReadInt32(buffer)
            Dim currentBuffer = buffer.PtrAdd(GetType(Integer))
            Dim table = New MIB_IPNETROW(0 To entries - 1) {}
            For index = 0 To entries - 1
                table(index) = DirectCast(Marshal.PtrToStructure(
                            currentBuffer.PtrAdd(GetType(MIB_IPNETROW), index), _
                        GetType(MIB_IPNETROW)), MIB_IPNETROW)
            Next
            For index = 0 To entries - 1
                With table(index)
                    Dim ip = New IPAddress(BitConverter.GetBytes(.dwAddr))
                    Console.Write(" IP: " & ip.ToString() & vbTab & " MAC: ")
                    PrintByte(.mac0)
                    PrintHyphenByte(.mac1)
                    PrintHyphenByte(.mac2)
                    PrintHyphenByte(.mac3)
                    PrintHyphenByte(.mac4)
                    PrintHyphenByte(.mac5)
                    If .dwPhysAddrLen <> 6 Then _
                        Console.Write(" Actual length: {0} ", .dwPhysAddrLen)
                    Console.Write(" Interface: 0x{0:X} Type: {1} ", .dwIndex, .dwType)
                End With
                Console.WriteLine()
            Next
        Finally
            ' Release the memory.
            Marshal.FreeCoTaskMem(buffer)
        End Try
        If Debugger.IsAttached Then _
            Console.ReadLine()
    End Sub
    <Extension()>
    Private Function PtrAdd(ByVal Ptr As IntPtr, ByVal Type As Type, Optional ByVal Index As Long = 1) As IntPtr
        Return New IntPtr(Ptr.ToInt64() +
            Index * Marshal.SizeOf(Type))
    End Function
    Private Sub PrintHyphenByte(ByVal b As Byte)
        Console.Write("-")
        PrintByte(b)
    End Sub
    Private Sub PrintByte(ByVal b As Byte)
        Console.Write(b.ToString("x2"))
    End Sub
    End Module
