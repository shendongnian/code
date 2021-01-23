        Using Reader As New Microsoft.VisualBasic.FileIO.TextFieldParser(CSVPath)
            Reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            Reader.Delimiters = New String() {","}
            Reader.TrimWhiteSpace = True
            Reader.HasFieldsEnclosedInQuotes = True
            While Not Reader.EndOfData
                Try
                    Dim st2 As New List(Of String)
                    st2.addrange(Reader.ReadFields())
                    If iCount > 0 Then ' ignore first row = field names
                        Dim p As New clsPerson
                        p.CSVLine = st2
                        While p.CSVLine.Count < 15
                            p.CSVLine.Add("")
                        End While
                        p.FirstName = st2(1).Trim
                        If st2.Count > 2 Then
                            p.MiddleName = st2(2).Trim
                        Else
                            p.MiddleName = ""
                        End If
                        p.LastNameSuffix = st2(0).Trim
                        If st2.Count >= 6 Then
                            p.TestCase = st2(5).Trim
                        End If
                        If st2(3) > "" Then
                            p.CertsFromCase.Add(st2(3))
                        End If
                        cases.Add(p)
                    Else
                        stFirstRow = CatLine(st2.ToArray)
                        Dim st3(6) As String
                        For kk As Integer = 0 To Math.Min(st2.Count - 1, 5)
                            st3(kk) = st2(kk)
                        Next
                        If 0 = InStr(st3(0), "Last Name", CompareMethod.Text) Or _
                         0 = InStr(st3(1), "First Name", CompareMethod.Text) Or _
                         0 = InStr(st3(2), "Middle Name", CompareMethod.Text) Or _
                         0 = InStr(st3(3), "Policy", CompareMethod.Text) Or _
                         0 = InStr(st3(5), "Test Case", CompareMethod.Text) Then
                            stFirstRow = "Last Name,First Name,Middle Name,Policy,,Test Case #" & vbCrLf & stFirstRow
                        End If
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is not valid and will be skipped.")
                End Try
                iCount += 1
            End While
        End Using
