    '1. store default styles when form is loading:
    Public Class aRoots
    Dim df1, df2, df3, df4 As Color
    Private Sub aRoots_Load(sender As Object, e As EventArgs) Handles Me.Load
            df1 = DGV_Root.DefaultCellStyle.SelectionBackColor
            df2 = DGV_Root.DefaultCellStyle.BackColor
            df3 = DGV_Root.DefaultCellStyle.SelectionForeColor
            df4 = DGV_Root.DefaultCellStyle.ForeColor
    ......
    '2. change cell styles when interacting with datagridview:
    Private Sub LoadRoot()
           For i = 0 To 5
                    DGV_Root.Rows.Add()
                    For j = 0 To 3
                        DGV_Root.Item(j, i).Value = ...
                    Next
                Next
            'DGV_Root.ClearSelection() ==> instead of this use 2 lines below
            DGV_Root.DefaultCellStyle.SelectionBackColor = df2
            DGV_Root.DefaultCellStyle.SelectionForeColor = df4
        End Sub
    '3. Change cell styles to default when selection is being changed like cell_click or cell_double click:
    Private Sub DGV_Root_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Root.CellMouseClick
            DGV_Root.DefaultCellStyle.SelectionBackColor = df1
            DGV_Root.DefaultCellStyle.SelectionForeColor = df3
    ...
    End Sub
    '4. restore all to default when u want to close form:
    Private Sub PbClose_Click(sender As Object, e As EventArgs) Handles PbClose.Click
            BtnCancel.PerformClick()
            DGV_Root.DefaultCellStyle.SelectionBackColor = df1
            DGV_Root.DefaultCellStyle.BackColor = df2
            DGV_Root.DefaultCellStyle.SelectionForeColor = df3
            DGV_Root.DefaultCellStyle.ForeColor = df4
            Me.Close()
    End Sub
