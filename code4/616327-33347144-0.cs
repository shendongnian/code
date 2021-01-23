    Public Sub MoveVerticalSplitter(grid As PropertyGrid, Fraction As Integer)
        Try
            Dim info = grid.[GetType]().GetProperty("Controls")
            Dim collection = DirectCast(info.GetValue(grid, Nothing), Control.ControlCollection)
            For Each control As Object In collection
                Dim type = control.[GetType]()
                If "PropertyGridView" = type.Name Then
                    control.LabelRatio = Fraction
                    grid.HelpVisible = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            Trace.WriteLine(ex)
        End Try
    End Sub
