    Imports System.Threading
    Public Class MyTabControl
        Inherits TabControl
        Private tabsImages As New Concurrent.ConcurrentDictionary(Of TabPage, List(Of String))
        Private tabsImagesKeys As New Concurrent.ConcurrentDictionary(Of TabPage, String)
        Private cycleImagesThread As Thread
        Private mInterval As Integer = 500
        Public Sub New()
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.DrawMode = TabDrawMode.OwnerDrawFixed
            cycleImagesThread = New Thread(AddressOf CycleImagesLoop)
            cycleImagesThread.Start()
        End Sub
        Protected Overrides Sub OnHandleCreated(e As EventArgs)
            If Me.FindForm IsNot Nothing Then AddHandler CType(Me.FindForm, Form).FormClosing, Sub() cycleImagesThread.Abort()
            MyBase.OnHandleCreated(e)
        End Sub
        Private Sub CycleImagesLoop()
            Do
                Thread.Sleep(mInterval)
                If tabsImagesKeys.Count > 0 Then
                    For Each tabImageKey In tabsImagesKeys
                        Dim index = tabsImages(tabImageKey.Key).IndexOf(tabImageKey.Value)
                        index += 1
                        index = index Mod tabsImages(tabImageKey.Key).Count
                        tabsImagesKeys(tabImageKey.Key) = tabsImages(tabImageKey.Key)(index)
                    Next
                    Me.Invalidate()
                End If
            Loop
        End Sub
        Public Property Interval As Integer
            Get
                Return mInterval
            End Get
            Set(value As Integer)
                mInterval = value
            End Set
        End Property
        Public Sub SetImages(tabPage As TabPage, images As List(Of String))
            If tabsImages.ContainsKey(tabPage) Then
                tabsImages(tabPage) = images
            Else
                tabsImages.TryAdd(tabPage, images)
            End If
            tabsImagesKeys(tabPage) = images.First()
        End Sub
        Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
            Dim g As Graphics = e.Graphics
            Dim r As Rectangle = e.Bounds
            Dim tab As TabPage = Me.TabPages(e.Index)
            Dim tabImage As Image
            Using b = New SolidBrush(IIf(e.State = DrawItemState.Selected, Color.White, Color.FromKnownColor(KnownColor.Control)))
                g.FillRectangle(b, r)
            End Using
            If tabsImagesKeys.Count > 0 OrElse Me.ImageList IsNot Nothing Then
                If tabsImagesKeys.ContainsKey(tab) Then
                    tabImage = Me.ImageList.Images(tabsImagesKeys(tab))
                    g.DrawImageUnscaled(tabImage, r.X + 4, r.Y + (r.Height - tabImage.Height) / 2)
                End If
                r.X += Me.ImageList.ImageSize.Width + 4
            End If
            Using b = New SolidBrush(tab.ForeColor)
                Dim textSize = g.MeasureString(tab.Text, tab.Font)
                g.DrawString(tab.Text, tab.Font, b, r.X, r.Y + (r.Height - textSize.Height) / 2)
            End Using
            MyBase.OnDrawItem(e)
        End Sub
    End Class
