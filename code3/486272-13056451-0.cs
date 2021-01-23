        Public Class CurveItemTagComparer
        Implements IComparer(Of CurveItem)
        Function Compare(ByVal x As ZedGraph.CurveItem, ByVal y As ZedGraph.CurveItem) As Integer _
        Implements System.Collections.Generic.IComparer(Of CurveItem).Compare
            Return CInt(x.Tag).CompareTo(CInt(y.Tag))
        End Function
    End Class
