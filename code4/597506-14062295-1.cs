    Public Class linectl   
    
        Public Sub DrawMe(ByVal g As Graphics, ByVal otherctl As Control)
            Dim where As New Rectangle(otherctl.Left - Left, otherctl.Top - Top, otherctl.Width - 1, otherctl.Height - 1)
            g.FillEllipse(Brushes.Red, where)
            g.DrawEllipse(Pens.Black, where)
        End Sub
    
        Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaintBackground(e)
            DrawMe(e.Graphics, Me)
            drawneighbors()
        End Sub
    
        Private Sub linectl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
            Me.Left += 10
        End Sub
    
        Private Sub linectl_MoveResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move, Me.Resize
            If Parent IsNot Nothing Then
                For Each c In From ctl In Parent.Controls Where TypeOf ctl Is linectl Select CType(ctl, linectl)
                    Using g = c.CreateGraphics
                        g.Clear(c.BackColor)
                        c.DrawMe(g, c)
                        c.drawneighbors()
                    End Using
                Next
            End If
        End Sub
    
        Public Sub drawneighbors()
            If Parent IsNot Nothing Then
                Dim ctls = (From ctl In Parent.Controls Where TypeOf ctl Is linectl Let c = CType(ctl, linectl) _
                            Select New With {.ctl = c, _
                                .rect = New Rectangle(c.Left, c.Top, c.Width, c.Height)}).ToArray.Reverse
                For Each ctl In ctls
                    Dim ctl_unclosed = ctl
                    For Each ictl In (From c In ctls Where ctl_unclosed.rect.IntersectsWith(c.rect))
                        Using g = ictl.ctl.CreateGraphics
                            ictl.ctl.DrawMe(g, Me)
                        End Using
                        Using g = Me.CreateGraphics
                            Me.DrawMe(g, ictl.ctl)
                        End Using
                    Next
                Next
            End If
        End Sub
    
    End Class
