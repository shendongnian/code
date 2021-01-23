    Function Rank(Of T As IComparable)(list As IEnumerable(Of T), item As T) As Integer
    	Return list.Count(Function(x) x.CompareTo(item) < 0) + 1
    End Function
    
    Public Sub Main()
    	Dim l = New Integer() {9, 1, 3, 8, 4, 6}
    	Console.WriteLine("6 is the " & Rank(l,6) & "th element of ")
    	Console.WriteLine([String].Join(" ", l))
    End Sub
    
    6 is the 4th element of
    9 1 3 8 4 6
