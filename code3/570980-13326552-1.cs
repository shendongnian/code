    Private Sub SwapControls(tlp As TableLayoutPanel, pos1 As TableLayoutPanelCellPosition, pos2 As TableLayoutPanelCellPosition)
      Dim ctl1 As Control = tlp.GetControlFromPosition(pos1.Column, pos1.Row)
      Dim ctl2 As Control = tlp.GetControlFromPosition(pos2.Column, pos2.Row)
      SwapControls(tlp, ctl1, ctl2)
    End Sub
