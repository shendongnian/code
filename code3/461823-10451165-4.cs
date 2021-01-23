    Imports System
    Imports System.Reflection
    Imports System.IO
    Public Class MainClass
	    Public Shared Function Main(args As String()) As Integer
		    Dim a As Assembly = Nothing
		    Try
			    a = Assembly.Load("YourLibraryName")
		    Catch e As FileNotFoundException
			    Console.WriteLine(e.Message)
		    End Try
		    Dim classType As Type = a.[GetType]("YourLibraryName.ClassName")
		    Dim obj As Object = Activator.CreateInstance(classType)
		    Dim [paramArray] As Object() = New Object(0) {}
		    [paramArray](0) = New SortledList(Of DateTime, Double)()
		    Dim mi As MethodInfo = classType.GetMethod("ComputeMeanPosition")
		    mi.Invoke(obj, [paramArray])
		    Return 0
	    End Function
    End Class
