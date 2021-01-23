    Public Event PropertyChanged As PropertyChangedEventHandler _
            Implements INotifyPropertyChanged.PropertyChanged
    
    Private Property m_prop As String
        Public Property Prop As String
            Get
                Return m_prop 
            End Get
            Set(value As String)
                Me.m_prop = value
                NotifyPropertyChanged("Prop")
            End Set
        End Property
    
    Private Sub NotifyPropertyChanged(ByVal info As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub
