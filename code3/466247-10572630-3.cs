    Public Class Form1
        Public Sub New()
            InitializeComponent()
            PrintDocument1.PrintController = New System.Drawing.Printing.StandardPrintController
        End Sub
    End Class
