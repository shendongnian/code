    Imports System.ComponentModel
    Imports System.Runtime.CompilerServices
    
    Public MustInherit Class BaseModel
        Implements INotifyPropertyChanged
        Protected Function SetProperty(Of T)(ByRef storage As T, value As T, <CallerMemberName> Optional propertyName As String = Nothing) As Boolean
            If Equals(storage, value) Then Return False
            storage = value
            OnPropertyChanged(propertyName)
            Return True
        End Function
    
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    
        Protected Overridable Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
