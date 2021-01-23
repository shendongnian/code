    Private Sub CardView1_CustomDrawCardCaption(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Card.CardCaptionCustomDrawEventArgs) Handles CardView1.CustomDrawCardCaption
        Dim view As DevExpress.XtraGrid.Views.Card.CardView = sender
        Dim s As String = String.Format("Subject: {0}", view.GetRowCellDisplayText(e.RowHandle, "ProductName"))
        CType(e.CardInfo, DevExpress.XtraGrid.Views.Card.ViewInfo.CardInfo).CaptionInfo.CardCaption = s
    End Sub
