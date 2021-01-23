    Public Class ClassForTheMagic
 
      Public Shared Function GetItemsForComboBox(ByVal txtBox1 As String, ByVal checkBox2 As Boolean, ...) As List(of ListItem)
          Dim itemList As New List(Of ListItem)
          itemList.Add(New ListItem(txtBox1, "..."))
          itemList.Add(New ListItem(checkBox2, "..."))
          ...
          Return itemList
      End Function
    End Class
