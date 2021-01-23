    Structure Person
        Public ID As Integer 
        Public MonthlySalary As Decimal 
        Public LastReviewDate As Long
        <VBFixedString(15)> Public FirstName As String
        <VBFixedString(15)> Public LastName As String
        <VBFixedString(15)> Public Title As String
        <VBFixedString(150)> Public ReviewComments As String 
    End Structure
