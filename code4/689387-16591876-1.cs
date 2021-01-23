    Protected Sub OnPropertyChanged(ByVal name As String)
    	RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub
    
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
    	OnPropertyChanged("propGender")
    End Sub
    
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
    	OnPropertyChanged("propGender")
    End Sub
