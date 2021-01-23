    // in the loop
    Row = DT.NewRow();
    string abbrCell1 = dataGridView6.Rows[i].Cells[0].Value.ToString();
    string abbrCell2 = dataGridView6.Rows[i].Cells[1].Value.ToString();
    IEnumerable<string> unabbrWords1 = abbrCell1.Split().Select(w => new { Word = w })
        .Where(x => dict.ContainsKey(x.Word))
        .Select(x => dict[x.Word]);
    IEnumerable<string> unabbrWords2 = abbrCell2.Split().Select(w => new { Word = w })
        .Where(x => dict.ContainsKey(x.Word))
        .Select(x => dict[x.Word]);
    Row[0] = string.Join(" ", unabbrWords1);
    Row[1] = string.Join(" ", unabbrWords2);
    DT.Rows.Add(Row);
