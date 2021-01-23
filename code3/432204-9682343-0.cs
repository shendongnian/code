    For i As Int16 = 0 To Me.ComboBox1.Items.Count - 2
         For j As Int16 = Me.ComboBox1.Items.Count - 1 To i + 1 Step -1
              If Me.ComboBox1.Items(i).ToString = Me.ComboBox1.Items(j).ToString Then
                   Me.ComboBox1.Items.RemoveAt(j)
              End If
         Next
    Next
