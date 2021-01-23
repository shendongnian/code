    Public Function HSVToColor(ByVal H As Double, ByVal S As Double, ByVal V As Double) As Color
      Dim Hi As Integer = (H / 60) Mod 6
      Dim f As Double = H / 60 Mod 1
      Dim p As Integer = V * (1 - S) * 255
      Dim q As Integer = V * (1 - f * S) * 255
      Dim t As Integer = V * (1 - (1 - f) * S) * 255
      Select Case Hi
        Case 0 : Return Color.FromArgb(V * 255, t, p)
        Case 1 : Return Color.FromArgb(q, V * 255, p)
        Case 2 : Return Color.FromArgb(p, V * 255, t)
        Case 3 : Return Color.FromArgb(p, V * 255, q)
        Case 4 : Return Color.FromArgb(t, p, V * 255)
        Case 5 : Return Color.FromArgb(V * 255, q, p)
      End Select
    End Function
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
      Dim normalSaturation As Color = Color.FromArgb(255, 216, 53, 45)
      Me.CreateGraphics.FillRectangle(New SolidBrush(normalSaturation), 100, 0, 100, 100)
      Dim reducedSaturation As Color = HSVToColor(normalSaturation.GetHue, normalSaturation.GetSaturation / 1.3, normalSaturation.GetBrightness)
      Dim reducedSaturation2 As Color = Color.FromArgb(40, reducedSaturation)
      Me.CreateGraphics.FillRectangle(New SolidBrush(reducedSaturation2), 0, 0, 100, 100)
    End Sub
