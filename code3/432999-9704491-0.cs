    Public Class BitmapImageToImageConverter
        Implements IValueConverter
    
        Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
            Dim bitmapImage = TryCast(value, BitmapImage)
            Dim height As Double = 0
    
            Dim returnImage As New Image()
    
            If bitmapImage IsNot Nothing Then
                returnImage.Height = 15
    
                If parameter IsNot Nothing AndAlso Double.TryParse(parameter.ToString, height) Then
                    returnImage.Height = height
                End If
    
                returnImage.Source = bitmapImage
            Else
                ' Set a default image if none is given
                Dim uriString = "pack://application:,,,/Resources/Images/nopicture.png"
    
                Dim img As New BitmapImage()
                img.BeginInit()
                img.UriSource = New Uri(uriString)
                img.EndInit()
    
                returnImage.Source = img
            End If
    
            Return returnImage
        End Function
    
    
        Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
