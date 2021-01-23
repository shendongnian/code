    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Dim dict As Dictionary(Of Integer, Integer) = GetDictionaryWithData()
      Try
        DoProcessing(dict)
      Catch ex As AggregateException
        RichTextBox1.Text = ex.ToString
      End Try
    End Sub
    
    Private Function GetDictionaryWithData() As Dictionary(Of Integer, Integer)
      Dim dict As New Dictionary(Of Integer, Integer)
      With dict
        .Add(5, 5) : .Add(4, 0) : .Add(3, 0) : .Add(2, 2) : .Add(1, 0)
      End With
      Return dict
    End Function
    
    Private Sub DoProcessing(dict As Dictionary(Of Integer, Integer))
      Dim exceptions As New List(Of Exception)
      For i = 0 To dict.Count - 1
        Dim key As Integer = dict.Keys(i)
        Dim value As Integer = dict.Values(i)
        Try
          Dim result As Integer = key \ value
        Catch ex As Exception
          exceptions.Add(ex)
        End Try
      Next
      If exceptions.Count > 0 Then Throw New AggregateException(exceptions)
    End Sub
