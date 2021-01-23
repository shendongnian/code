    #Region " FreeImage Helper "
    
    ' [ FreeImage Helper ]
    '
    ' // By Elektro H@cker
    '
    '
    ' INSTRUCTIONS:
    ' 1. ADD A REFERENCE FOR "FreeImageNET.dll" IN THE PROJECT.
    ' 2. ADD THE "FREEIMAGE.DLL" IN THE PROJECT.
    '
    '
    ' Examples :
    '
    ' MsgBox(FreeImageHelper.Is_Avaliable() ' Result: True
    ' MsgBox(FreeImageHelper.Get_Version()  ' Result: 3.15.1
    ' MsgBox(FreeImageHelper.Get_ImageFormat("C:\Test.png")) ' Result: PNG
    '
    ' FreeImageHelper.Convert("C:\Test.png", "C:\Test.ico", FreeImageAPI.FREE_IMAGE_FORMAT.FIF_ICO)
    ' FreeImageHelper.Convert(New Bitmap("C:\Test.png"), "C:\Test.jpg", FreeImageAPI.FREE_IMAGE_FORMAT.FIF_JPEG, FreeImageAPI.FREE_IMAGE_SAVE_FLAGS.JPEG_SUBSAMPLING_444 Or FreeImageAPI.FREE_IMAGE_SAVE_FLAGS.JPEG_QUALITYSUPERB)
    '
    ' PictureBox1.BackgroundImage = FreeImageHelper.GrayScale(New Bitmap("C:\Test.bmp"))
    ' PictureBox1.BackgroundImage = FreeImageHelper.GrayScale("C:\Test.bmp")
    '
    ' PictureBox1.BackgroundImage = FreeImageHelper.Resize(New Bitmap("C:\Test.bmp"), 32, 32)
    ' PictureBox1.BackgroundImage = FreeImageHelper.Resize("C:\Test.bmp", 64, 128)
    '
    ' PictureBox1.BackgroundImage = FreeImageHelper.Rotate(New Bitmap("C:\Test.bmp"), 90)
    ' PictureBox1.BackgroundImage = FreeImageHelper.Rotate("C:\Test.bmp", -90)
    '
    ' PictureBox1.BackgroundImage = FreeImageHelper.Thumbnail(New Bitmap("C:\Test.png"), 64, True)
    ' PictureBox1.BackgroundImage = FreeImageHelper.Thumbnail("C:\Test.png", 64, True)
    
    
    
    Imports FreeImageAPI
    
    Public Class FreeImageHelper
    ' <summary>
    ' Checks if <i>FreeImage.dll</i> is avaliable on the system.
    ' </summary>
    Public Shared Function Is_Avaliable() As Boolean
        Return FreeImage.IsAvailable
    End Function
    ' <summary>
    ' Gets the version of FreeImage.dll.
    ' </summary>
    Shared Function Get_Version() As String
        Return FreeImage.GetVersion
    End Function
    ' <summary>
    ' Gets the image format of a image file.
    ' </summary>
    Shared Function Get_ImageFormat(ByVal File As String) As String
        Return FreeImage.GetFileType(File, 0).ToString.Substring(4)
    End Function
    ' <summary>
    ' Convert a Bitmap object between image formats and save it to disk.
    ' </summary>
    Shared Sub Convert(ByVal bmp As System.Drawing.Bitmap, _
                       ByVal Output As String, _
                       ByVal NewFormat As FREE_IMAGE_FORMAT, _
                       Optional ByVal SaveFlags As FREE_IMAGE_SAVE_FLAGS = FREE_IMAGE_SAVE_FLAGS.DEFAULT)
        Try
            FreeImage.SaveBitmap(bmp, Output, NewFormat, SaveFlags)
        Catch ex As Exception
            ' Throw New Exception(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub
    ' <summary>
    ' Convert a image file between image formats and save it to disk.
    ' </summary>
    Shared Sub Convert(ByVal File As String, _
                       ByVal Output As String, _
                       ByVal NewFormat As FREE_IMAGE_FORMAT, _
                       Optional ByVal SaveFlags As FREE_IMAGE_SAVE_FLAGS = FREE_IMAGE_SAVE_FLAGS.DEFAULT)
        Try
            FreeImage.Save(NewFormat, FreeImage.LoadEx(File), Output, SaveFlags)
        Catch ex As Exception
            ' Throw New Exception(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub
    ' <summary>
    ' GrayScales a Bitmap object.
    ' </summary>
    Shared Function GrayScale(ByVal bmp As System.Drawing.Bitmap) As System.Drawing.Bitmap
        Try
            Dim ImageStream As New System.IO.MemoryStream
            bmp.Save(ImageStream, bmp.RawFormat)
            Dim Image As FIBITMAP = FreeImage.LoadFromStream(ImageStream)
            ImageStream.Dispose()
            Return FreeImage.GetBitmap(FreeImage.ConvertToGreyscale(Image))
        Catch ex As Exception
            ' Throw New Exception(ex.Message)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    ' <summary>
    ' GrayScales a image file.
    ' </summary>
    Shared Function GrayScale(ByVal File As String) As System.Drawing.Bitmap
        Try
            Return FreeImage.GetBitmap(FreeImage.ConvertToGreyscale(FreeImage.LoadEx(File)))
        Catch ex As Exception
            ' Throw New Exception(ex.Message)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    ' <summary>
    ' Resizes a Bitmap object.
    ' </summary>
    Shared Function Resize(ByVal bmp As System.Drawing.Bitmap, _
                           ByVal X As Int32, _
                           ByVal Y As Int32, _
                           Optional ByVal Quality As FREE_IMAGE_FILTER = FREE_IMAGE_FILTER.FILTER_BILINEAR) As System.Drawing.Bitmap
        Try
            Dim ImageStream As New System.IO.MemoryStream
            bmp.Save(ImageStream, bmp.RawFormat)
            Dim Image As FIBITMAP = FreeImage.LoadFromStream(ImageStream)
            ImageStream.Dispose()
            Return FreeImage.GetBitmap(FreeImage.Rescale(Image, X, Y, Quality))
        Catch ex As Exception
            ' Throw New Exception(ex.Message)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    ' <summary>
    ' Resizes a image file.
    ' </summary>
    Shared Function Resize(ByVal File As String, _
                           ByVal X As Int32, _
                           ByVal Y As Int32, _
                           Optional ByVal Quality As FREE_IMAGE_FILTER = FREE_IMAGE_FILTER.FILTER_BILINEAR) As System.Drawing.Bitmap
        Try
            Return FreeImage.GetBitmap(FreeImage.Rescale(FreeImage.LoadEx(File), X, Y, Quality))
        Catch ex As Exception
            ' Throw New Exception(ex.Message)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    ' <summary>
    ' Rotates a Bitmap object.
    ' </summary>
    Shared Function Rotate(ByVal bmp As System.Drawing.Bitmap, _
                           ByVal Angle As Double) As System.Drawing.Bitmap
        Try
            Dim ImageStream As New System.IO.MemoryStream
            bmp.Save(ImageStream, bmp.RawFormat)
            Dim Image As FIBITMAP = FreeImage.LoadFromStream(ImageStream)
            ImageStream.Dispose()
            Return FreeImage.GetBitmap(FreeImage.Rotate(Image, Angle))
        Catch ex As Exception
            ' Throw New Exception(ex.Message)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    ' <summary>
    ' Rotates a image file.
    ' </summary>
    Shared Function Rotate(ByVal File As String, _
                           ByVal Angle As Double) As System.Drawing.Bitmap
        Try
            Return FreeImage.GetBitmap(FreeImage.Rotate(FreeImage.LoadEx(File), Angle))
        Catch ex As Exception
            ' Throw New Exception(ex.Message)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    ' <summary>
    ' Returns a Thumbnail of a Bitmap object.
    ' </summary>
    Shared Function Thumbnail(ByVal bmp As System.Drawing.Bitmap, _
                                   ByVal size As Int32, _
                                   ByVal convert As Boolean) As System.Drawing.Bitmap
        Try
            Dim ImageStream As New System.IO.MemoryStream
            bmp.Save(ImageStream, bmp.RawFormat)
            Dim Image As FIBITMAP = FreeImage.LoadFromStream(ImageStream)
            ImageStream.Dispose()
            Return FreeImage.GetBitmap(FreeImage.MakeThumbnail(Image, size, convert))
        Catch ex As Exception
            ' Throw New Exception(ex.Message)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    ' <summary>
    ' Returns a Thumbnail of a image file.
    ' </summary>
    Shared Function Thumbnail(ByVal File As String, _
                                   ByVal size As Int32, _
                                   ByVal convert As Boolean) As System.Drawing.Bitmap
        Try
            Return FreeImage.GetBitmap(FreeImage.MakeThumbnail(FreeImage.LoadEx(File), size, convert))
        Catch ex As Exception
            ' Throw New Exception(ex.Message)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    End Class
    
    #End Region
