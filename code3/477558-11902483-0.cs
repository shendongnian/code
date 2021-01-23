    Public Class View
    
       Private WithEvents _VM AS new ViewModel()
    
       Private Sub _VM_AddingItem(Sender AS Object, E AS ViewModel.ItemEventArgs)
          Dim Dialog As new SomeDialog()
    
          If Dialog.ShowDialog then 
             E.Item = Dialog.Item
          Else
             E.Cancel = True
          End If
       End Sub 
    
    End Class
       
    
    Public Class ViewModel 
       Public Sub AddItem(Item AS Object) 
           Do Some Work here 
        End Sub 
        
        Private Sub _AddItem() 
           Dim Args AS New ItemEventArgs()
        
           OnAddingItem(Args)
        
           If not Args.Cancel Then AddItem(Args.Item)
        End Sub 
        
        Protected Sub OnAddingItem() 
           RaiseEvent AddingItem(me, ItemEventArgs)
        End Sub
    
        Public Event AddingItem(Sender AS Object, E As ItemEventArgs)
        
        Public Class ItemEventArgs
           Public Property Item AS Object
           Public Property Cancel AS Boolean = false
        End Class
    End Class
