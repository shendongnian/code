    Sub TestCompare2()
        '{=SUM(IF($A$1:$A$4=$B$1:$B$4,1,0))=ROWS($A$1:$A$4)}
        Dim rngA As Range
        Dim rngB As Range
        Dim varCalc As Variant
        Dim blnTheSame As Boolean
        
        Set rngA = Range("$A$1:$A$4")
        Set rngB = Range("$B$1:$B$4")
        varCalc = "=SUM(IF(" & rngA.Address & "=" _
            & rngB.Address & ",1,0))=ROWS(" & rngA.Address & ")"
        blnTheSame = Evaluate(Array(varCalc))
        MsgBox "Are they the same? " & blnTheSame
    End Sub
