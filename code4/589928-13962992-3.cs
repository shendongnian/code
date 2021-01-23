    Imports System.Collections.Generic
    Imports System.Linq
    Imports System.Runtime.CompilerServices
    Imports ConsoleApplication2Helpers.My35Extensions
    
    
    Module Module1
    
        Sub Main()
            Dim obj1 As New MyType, obj2 As New MyType, obj3 As New MyType, obj4 As New MyType
            Dim list1 As New List(Of MyType) From {obj1, obj2}
            Dim list2 As New List(Of MyType) From {obj3, obj4}
            Dim arg1 = {list1, list2}
    
            ' Works in 3.5 and 4.  The non-generic array can be implicitly converted to IEnumerable.
            ' Then the framework only has one more dimension for the second IEnumerable conversion.
            ' The single dimension can convert implicitly in .NET 3.5 or 4.
            MyMethod(arg1)
    
    
            Dim arg2 As New List(Of List(Of MyType))
            arg2.Add(list1)
            arg2.Add(list2)
    
            ' Works in .NET 4 but NOT 3.5 because .NET Framework 4 introduces variance support for several existing generic interfaces.
            'MyMethod(arg2)
    
            ' Works in .NET 4 or 3.5.
            ' Uses custom extension method to implicitly convert the outer List<T> to IEnumerable<T>, so we can run in .NET 3.5.
            MyMethod(arg2.ToIEnumerableOfIEnumerable())
    
            Console.ReadKey()
        End Sub
    
        Sub MyMethod(value As IEnumerable(Of IEnumerable(Of MyType)))
            '
        End Sub
    
    End Module
    
    
    Public Class MyType
        Public Sub New()
    
        End Sub
    End Class
