    Imports System.Runtime.CompilerServices
    Imports System.Globalization
    Imports System.Text
    
    Public Module StringExclusions
    
            <Extension()> Public Function CharsToString(ByVal val As IEnumerable(Of Char)) As String
                Dim bldr As New StringBuilder()
                bldr.Append(val.ToArray)
                Return bldr.ToString()
            End Function
    
            <Extension()> Public Function RemoveCategories(ByVal val As String, ByVal categories As IEnumerable(Of UnicodeCategory)) As String
                Return (From chr As Char In val.ToCharArray Where Not categories.Contains(Char.GetUnicodeCategory(chr))).CharsToString
            End Function
    
            Public Function WhiteSpaceCategories() As IEnumerable(Of UnicodeCategory)
                Return New List(Of UnicodeCategory) From {UnicodeCategory.SpaceSeparator, UnicodeCategory.LineSeparator, UnicodeCategory.Control}
            End Function
            '...Other commonly used categories removed for brevity.
        End Module
