    Dim n = "1001055522"
    Dim doubles = System.Text.RegularExpressions.Regex.Matches(n, "(.)\1")
    Dim triples = System.Text.RegularExpressions.Regex.Matches(n, "(.)\1{2}")
    'Doubles
    For Each d As System.Text.RegularExpressions.Match In doubles
        Console.WriteLine(d.Value)
    Next
    'Triples
    For Each t As System.Text.RegularExpressions.Match In triples
        Console.WriteLine(t.Value)
    Next
