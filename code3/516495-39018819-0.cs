    Public Shared Sub InitPlaceholder(canvas As Canvas)
        Dim txt As TextBox = canvas.Children.OfType(Of TextBox).First()
        Dim placeHolderLabel = New TextBlock() With {.Text = txt.Tag,
                                                     .Foreground = New SolidColorBrush(Color.FromRgb(&H77, &H77, &H77)),
                                                     .IsHitTestVisible = False}
        Canvas.SetLeft(placeHolderLabel, 3)
        Canvas.SetTop(placeHolderLabel, 1)
        canvas.Children.Add(placeHolderLabel)
        AddHandler txt.TextChanged, Sub() placeHolderLabel.Visibility = If(txt.Text = "", Visibility.Visible, Visibility.Hidden)
    End Sub
