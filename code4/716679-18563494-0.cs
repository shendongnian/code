        Public Function GetImageOutline(bi As BitmapImage) As Geometry
		Dim stride As Integer = bi.PixelWidth * 4
		Dim height As Integer = bi.PixelHeight
		Dim pg As New PathGeometry With {.FillRule = FillRule.Nonzero}
		Dim pixels(height * stride - 1) As Byte
		bi.CopyPixels(pixels, stride, 0)
		For i As Integer = 0 To pixels.Count - 1 Step 4
			'\\\Find non-transparent pixels (Alpha > 0):
			If pixels(i + 3) > 0 Then
				Dim x As Double = (i Mod stride) \ 4
				Dim y As Double = Math.Floor(i / stride)
				Dim pixG As New RectangleGeometry(New Rect(x, y, 1, 1))
				pg.AddGeometry(pixG)
			End If
		Next
		Return pg.GetOutlinedPathGeometry()
	End Function
