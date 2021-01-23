    For i As Integer = 0 To lvSubjects.Items.Count - 1
                Dim coll As ControlCollection = lvSubjects.Items(i).Controls
                For Each c As Control In coll
                    If TypeOf c Is CheckBox Then
                        Dim box As CheckBox = CType(c, CheckBox)
                        If box.Checked Then
                            MsgBox(box.Text)
                        End If
                    End If
                Next c
            Next i
