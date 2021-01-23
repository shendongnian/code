    Imports System.Drawing.Imaging
    Imports System.IO
    
    Public Class Icons
      Property UpgradeNum As String
      Property state As Iconstates
    
      Function GetIcon(Optional OptionalSave As String = "") As Icon
        Dim bmp As New Bitmap(16, 16)
    
        Using g = Graphics.FromImage(bmp)
          g.Clear(Color.Transparent)
          g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
          Select Case state
            Case Iconstates.OK
              g.FillEllipse(Brushes.Green, 1, 1, 14, 14)
          End Select
          g.DrawString(UpgradeNum, New Font("Small Fonts", 6), Brushes.Aquamarine, 0, 0)
        End Using
    
        bmp.Save(OptionalSave & ".png")
    
        Dim outputStream As New MemoryStream()
        Dim size As Integer = bmp.Size.Width
        If Not ConvertToIcon(bmp, outputStream, size) Then
          Return Nothing
        End If
        If OptionalSave > "" Then
    
          Using file = New FileStream(OptionalSave, FileMode.Create, System.IO.FileAccess.Write)
            outputStream.WriteTo(file)
            file.Close()
          End Using
        End If
    
        outputStream.Seek(0, SeekOrigin.Begin)
    
        Return New Icon(outputStream)
      End Function
    
    
    
    
      ''' <summary>
      ''' Converts a PNG image to an icon (ico)
      ''' </summary>
      ''' <param name="inputBitmap">The input stream</param>
      ''' <param name="output">The output stream</param>
      ''' <param name="size">Needs to be a factor of 2 (16x16 px by default)</param>
      ''' <param name="preserveAspectRatio">Preserve the aspect ratio</param>
      ''' <returns>Wether or not the icon was succesfully generated</returns>
      Public Shared Function ConvertToIcon(inputBitmap As Bitmap, output As Stream, Optional size As Integer = 16, Optional preserveAspectRatio As Boolean = False) As Boolean
    
        Dim width As Single = size, height As Single = size
    
    
        Dim newBitmap = New Bitmap(inputBitmap, New Size(CInt(width), CInt(height)))
        If newBitmap Is Nothing Then
          Return False
        End If
    
        ' save the resized png into a memory stream for future use
        Using memoryStream As New MemoryStream()
          newBitmap.Save(memoryStream, ImageFormat.Png)
    
          Dim iconWriter = New BinaryWriter(output)
          If output Is Nothing OrElse iconWriter Is Nothing Then
            Return False
          End If
    
          ' 0-1 reserved, 0
          iconWriter.Write(CByte(0))
          iconWriter.Write(CByte(0))
    
          ' 2-3 image type, 1 = icon, 2 = cursor
          iconWriter.Write(CShort(1))
    
          ' 4-5 number of images
          iconWriter.Write(CShort(1))
    
          ' image entry 1
          ' 0 image width
          iconWriter.Write(CByte(width))
          ' 1 image height
          iconWriter.Write(CByte(height))
    
          ' 2 number of colors
          iconWriter.Write(CByte(0))
    
          ' 3 reserved
          iconWriter.Write(CByte(0))
    
          ' 4-5 color planes
          iconWriter.Write(CShort(0))
    
          ' 6-7 bits per pixel
          iconWriter.Write(CShort(32))
    
          ' 8-11 size of image data
          iconWriter.Write(CInt(memoryStream.Length))
    
          ' 12-15 offset of image data
          iconWriter.Write(CInt(6 + 16))
    
          ' write image data
          ' png data must contain the whole png data file
          iconWriter.Write(memoryStream.ToArray())
    
          iconWriter.Flush()
        End Using
    
        Return True
      End Function
    
    
    End Class
    ' https://gist.github.com/darkfall/1656050
    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================
