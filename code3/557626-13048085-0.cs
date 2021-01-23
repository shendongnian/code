    Sub CommentFixer()
    Dim Arng As Range, Acl As Variant, InitRng As Variant, MaxSize
    Set InitRng = Selection
    Set Arng = Application.InputBox("Select Ranges", , , , , , , 8)
    
    For Each Acl In Arng
        If (Not (Acl.Comment Is Nothing)) And (Acl.MergeArea.Count = 1) Then
            Acl.Select
            Selection.Comment.Visible = True
            Selection.Comment.Shape.TextFrame.AutoSize = True
            'Commented as is obsolete if no further processing is needed  
            'Selection.Comment.Shape.Select
            'Commented not to fix Comment Aspect Ratio
            'With Selection.ShapeRange       'Fix 2.5 aspect ratio
            '    .LockAspectRatio = msoFalse
            '    MaxSize = .Width / 2.5
            '    If MaxSize > .Height Then
            '        .Height = MaxSize
            '    Else
            '        .Width = .Height * 2.5
            '    End If
            'End With
            'Commented to neglect fonts
            'With Selection.Font
            '    .Bold = False
            '    .Name = "Times New Roman"
            '    .Size = 12
            'End With
            
            Acl.Comment.Visible = False
        End If
    Next
    InitRng.Select
    
    End Sub
