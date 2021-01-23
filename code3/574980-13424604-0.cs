        Public Overrides Sub OnMouseDown(e As Ui.MouseEventArgs)
            MyBase.OnMouseDown(e)
            Dim localLoc As Point = ScreenToWindow(e.Location)
            'If Movable AndAlso localLoc.Y >= 0 AndAlso localLoc.Y <= mBackground.TopMargin Then
            If Closable AndAlso Me.CloseButtonBounds.Contains(e.Location) Then
                Me.OnCloseButton()
            ElseIf Movable AndAlso Me.DragArea.Contains(e.Location) Then
                mMouseAnchor = localLoc
                mDragType = DragType.Move
                ' ElseIf Resizable AndAlso localLoc.X > Me.Bounds.Width - mBackground.RightMargin AndAlso localLoc.Y > Me.Bounds.Height - mBackground.BottomMargin Then
            ElseIf Resizable AndAlso Me.ResizeArea.Contains(e.Location) Then
                mMouseAnchor = New Point(Me.Bounds.Right - e.Location.X, Me.Bounds.Bottom - e.Location.Y)
                mDragType = DragType.Resize
            End If
        End Sub
        Public Overrides Sub OnMouseUp(e As Ui.MouseEventArgs)
            MyBase.OnMouseUp(e)
            mDragType = DragType.None
        End Sub
        Public Overrides Sub OnMouseMove(e As Ui.MouseEventArgs)
            MyBase.OnMouseMove(e)
            If mDragType = DragType.Move Then
                Dim change As New Vector2((e.Location.X - mMouseAnchor.X) - Me.X, (e.Location.Y - mMouseAnchor.Y) - Me.Y)
                Me.Bounds = New Rectangle(e.Location.X - mMouseAnchor.X,
                                          e.Location.Y - mMouseAnchor.Y,
                                          Me.Bounds.Width,
                                          Me.Bounds.Height)
                UpdateControlLocations(change)
            ElseIf mResizable AndAlso mDragType = DragType.Resize Then
                Me.Bounds = New Rectangle(Me.Bounds.X,
                                          Me.Bounds.Y,
                                          Me.Bounds.Width - (Me.Bounds.Right - e.Location.X) + mMouseAnchor.X,
                                          Me.Bounds.Height - (Me.Bounds.Bottom - e.Location.Y) + mMouseAnchor.Y)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeNWSE
            ElseIf mDragType = DragType.None Then
                If mResizable AndAlso Me.ResizeArea.Contains(e.Location) Then
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeNWSE
                Else
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                End If
            End If
        End Sub
