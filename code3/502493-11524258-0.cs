    Public Class Form1
		Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
			BackgroundWorker1.RunWorkerAsync()
		End Sub
		Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
			Dim r As New Random()
			For index As Integer = 0 To 100
				Me.Invoke(Sub()
							  ListBox1.Items.Add(Guid.NewGuid().ToString())
						  End Sub)
				Threading.Thread.Sleep(r.Next(50, 300))
			Next
		End Sub
		Private Sub BackgroundWorker1_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
			Me.Invoke(Sub()
						  MsgBox("Task Complete", MsgBoxStyle.OkOnly, "Task Complete")
					  End Sub)
		End Sub
	End Class
