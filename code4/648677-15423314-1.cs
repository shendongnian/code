    Partial Public Class MainWindow
      Inherits Window
      Public Sub New()
        InitializeComponent()
        ''single initialization of messanger for catching message box
        Messenger.[Default].Register(Of DialogMessage)(Me, Sub(msg)
                                                               Dim result = MessageBox.Show(msg.Content, msg.Caption, msg.Button, MessageBoxImage.Warning)
                                                               ''Send callback
                                                               msg.ProcessCallback(result)
                                                           End Sub)
      End Sub
    End Class
