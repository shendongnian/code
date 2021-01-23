    List<content> rows = PlaceHolder_ForEntries.Controls.OfType<TextBox>()
        .Select(txt => new{
            Txt = txt,
            Number = new String(txt.ID.SkipWhile(c => !Char.IsDigit(c)).ToArray())
         })
        .GroupBy(x => x.Number)
        .Select(g => new content{ 
            name = g.First(x => x.Txt.ID.StartsWith("TextBox_Name")).Txt.Text,
            memberNo = g.First(x => x.Txt.ID.StartsWith("TextBox_MemberNo")).Txt.Text,
            points = int.Parse(g.First(x => x.Txt.ID.StartsWith("TextBox_Points")).Txt.Text)
        })
        .ToList();
