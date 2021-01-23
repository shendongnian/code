    Imports System.IO
    Imports ProtoBuf
    Public Class Entry
        Shared Sub Main()
            Dim l As New MyList
            l.Add("abc")
            Dim newList As MyList
            Using ms As New MemoryStream
                Serializer.Serialize(Of MyList)(ms, l)
                ms.Seek(0, SeekOrigin.Begin)
                newList = Serializer.Deserialize(Of MyList)(ms)
            End Using
            Console.WriteLine("Mylist ProtoBuf {0}", newList.Count = 1)
            Dim f As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Using ms As New MemoryStream
                f.Serialize(ms, l)
                ms.Seek(0, SeekOrigin.Begin)
                newList = CType(f.Deserialize(ms), MyList)
            End Using
            Console.WriteLine("Mylist BinaryFormatter {0}", newList.Count = 1)
            Dim l2 As New MyList2
            l2.Items.Add("abc")
            Dim newList2 As MyList2
            Using ms As New MemoryStream
                Serializer.Serialize(Of MyList2)(ms, l2)
                ms.Seek(0, SeekOrigin.Begin)
                newList2 = Serializer.Deserialize(Of MyList2)(ms)
            End Using
            Console.WriteLine("Mylist2 ProtoBuf {0}", newList2.Items.Count = 1)
            Dim li As New MyListI
            li.Add(5)
            Dim newListi As MyListI
            Using ms As New MemoryStream
                Serializer.Serialize(Of MyListI)(ms, li)
                ms.Seek(0, SeekOrigin.Begin)
                newListi = Serializer.Deserialize(Of MyListI)(ms)
            End Using
            Console.WriteLine("MyListI ProtoBuf {0}", newListi.Count = 1)
            Dim lh As New MyListThing
            lh.Add(New Thing() With {.Message = "abc"})
            Dim newListh As MyListThing
            Using ms As New MemoryStream
                Serializer.Serialize(Of MyListThing)(ms, lh)
                ms.Seek(0, SeekOrigin.Begin)
                newListh = Serializer.Deserialize(Of MyListThing)(ms)
            End Using
            Console.WriteLine("MyListThing ProtoBuf {0}", newListh.Count = 1)
        End Sub
    End Class
    <ProtoContract(), Serializable()>
    Public Class MyList
        Inherits List(Of String)
    End Class
    <ProtoContract()>
    Public Class MyList2
        Public Sub New()
            Items = New List(Of String)
        End Sub
        <ProtoMember(1)>
        Public Property Items As List(Of String)
    End Class
    <ProtoContract()>
    Public Class MyListI
        Inherits List(Of Integer)
    End Class
    <ProtoContract()>
    Public Class MyListThing
        Inherits List(Of Thing)
    End Class
    <ProtoContract()>
    Public Class Thing
        <ProtoMember(1)>
        Public Property Message As String
    End Class
