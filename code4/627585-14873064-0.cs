    List<content> rows = PlaceHolder_ForEntries.Controls.OfType<TextBox>()
        .Select(txt => new{
            Txt = txt,
            Number = new String(txt.Id.SkipWhile(c => !Char.IsDigit(c)))
         })
        .GroupBy(x => x.Number)
        .Select(g => new content{ 
            name = g.First(x => x.Txt.Id.StartsWith("TextBox_Name")).Text,
            memberNo = g.First(x => x.Txt.Id.StartsWith("TextBox_MemberNo")).Text,
            points = int.Parse(g.First(x => x.Txt.Id.StartsWith("TextBox_Points")).Text)
        })
        .ToList();
