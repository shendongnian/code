    Imports System.Text.RegularExpressions
    Class FuzzyDateTime
    Shared dayList As New List(Of String)() From { _
     "sun", _
     "mon", _
     "tue", _
     "wed", _
     "thu", _
     "fri", _
     "sat" _
    }
    Shared parsers As New List(Of IDateTimePattern)() From { _
     New RegexDateTimePattern("next +([2-9]\d*) +months", Function(m As Match)
                                                              Dim val = Integer.Parse(m.Groups(1).Value)
                                                              Return DateTime.Now.AddMonths(val)
                                                          End Function), _
     New RegexDateTimePattern("next +month", Function(m As Match) DateTime.Now.AddMonths(1)), _
     New RegexDateTimePattern("next +([2-9]\d*) +days", Function(m As Match)
                                                            Dim val = Integer.Parse(m.Groups(1).Value)
                                                            Return DateTime.Now.AddDays(val)
                                                        End Function), _
     New RegexDateTimePattern("([2-9]\d*) +months +ago", Function(m As Match)
                                                             Dim val = Integer.Parse(m.Groups(1).Value)
                                                             Return DateTime.Now.AddMonths(-val)
                                                         End Function), _
     New RegexDateTimePattern("([2-9]\d*) days +ago", Function(m As Match)
                                                          Dim val = Integer.Parse(m.Groups(1).Value)
                                                          Return DateTime.Now.AddDays(-val)
                                                      End Function), _
     New RegexDateTimePattern("([2-9]\d*) *h(ours)? +ago", Function(m As Match)
                                                               Dim val = Integer.Parse(m.Groups(1).Value)
                                                               Return DateTime.Now.AddMonths(-val)
                                                           End Function), _
     New RegexDateTimePattern("tomorrow", Function(m As Match) DateTime.Now.AddDays(1)), _
     New RegexDateTimePattern("today", Function(m As Match) DateTime.Now), _
     New RegexDateTimePattern("yesterday", Function(m As Match) DateTime.Now.AddDays(-1)), _
     New RegexDateTimePattern("(last|next) *(year|month)", Function(m As Match)
                                                               Dim direction As Integer = If((m.Groups(1).Value = "last"), -1, 1)
                                                               Select Case m.Groups(2).Value
                                                                   Case "year"
                                                                       Return New DateTime(DateTime.Now.Year + direction, 1, 1)
                                                                   Case "month"
                                                                       Return New DateTime(DateTime.Now.Year, DateTime.Now.Month + direction, 1)
                                                               End Select
                                                               Return DateTime.MinValue
                                                               ''#handle weekdays
                                                           End Function), _
     New RegexDateTimePattern([String].Format("(last|next) *({0}).*", [String].Join("|", dayList.ToArray())), Function(m As Match)
                                                                                                                  Dim val = m.Groups(2).Value
                                                                                                                  Dim direction = If((m.Groups(1).Value = "last"), -1, 1)
                                                                                                                  Dim dayOfWeek = dayList.IndexOf(val.Substring(0, 3))
                                                                                                                  If dayOfWeek >= 0 Then
                                                                                                                      Dim diff = direction * (dayOfWeek - CInt(DateTime.Today.DayOfWeek))
                                                                                                                      If diff <= 0 Then
                                                                                                                          diff = 7 + diff
                                                                                                                      End If
                                                                                                                      Return DateTime.Today.AddDays(direction * diff)
                                                                                                                  End If
                                                                                                                  Return DateTime.MinValue
                                                                                                                  ''# to parse months using DateTime.TryParse
                                                                                                              End Function), _
     New RegexDateTimePattern("(last|next) *(.+)", Function(m As Match)
                                                       Dim dt As DateTime
                                                       Dim direction As Integer = If((m.Groups(1).Value = "last"), -1, 1)
                                                       Dim s = [String].Format("{0} {1}", m.Groups(2).Value, DateTime.Now.Year + direction)
                                                       If DateTime.TryParse(s, dt) Then
                                                           Return dt
                                                       Else
                                                           Return DateTime.MinValue
                                                       End If
                                                       ''#as final resort parse using DateTime.TryParse
                                                   End Function), _
     New RegexDateTimePattern(".*", Function(m As Match)
                                        Dim dt As DateTime
                                        Dim s = m.Groups(0).Value
                                        If DateTime.TryParse(s, dt) Then
                                            Return dt
                                        Else
                                            Return DateTime.MinValue
                                        End If
                                    End Function) _
    }
        Public Shared Function Parse(text As String) As DateTime
            text = text.Trim().ToLower()
            Dim dt = DateTime.Now
            For Each parser In parsers
                dt = parser.Parse(text)
                If dt <> DateTime.MinValue Then
                    Exit For
                End If
            Next
            Return dt
        End Function
    End Class
    Interface IDateTimePattern
        Function Parse(text As String) As DateTime
    End Interface
    
    Class RegexDateTimePattern
        Implements IDateTimePattern
        Public Delegate Function Interpreter(m As Match) As DateTime
        Protected regEx As Regex
        Protected inter As Interpreter
        Public Sub New(re As String, inter As Interpreter)
            Me.regEx = New Regex(re)
            Me.inter = inter
        End Sub
        Public Function Parse(text As String) As DateTime Implements IDateTimePattern.Parse
            Dim m = regEx.Match(text)
    
            If m.Success Then
                Return inter(m)
            End If
            Return DateTime.MinValue
        End Function
    End Class
