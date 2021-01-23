     Public Function GetExamByExamID(ExamID As Integer) As Exam
        Dim myExam As New Exam(0, "", 0, "", "")
        For Each exam1 As exam In ExamArray
            If exam1.ExamID = ExamID Then
                With myExam
                    .ExamID = exam1.ExamID
                    .ExamTitle = exam1.ExamTitle
                    .CreditHours = exam1.CreditHours
                    .Description = exam1.Description
                    .PrerequisiteExam = exam1.PrerequisiteExam
                End With
                Return myExam
            End If
        Next
        Return Nothing
    End Function
