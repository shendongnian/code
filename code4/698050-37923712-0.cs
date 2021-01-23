    [Test]
    public void ExploreRxReplace()
    {
        var txt = " ABC XYZ DEF ";
        var exp = " *** XYZ xxx ";
        var rx = new Regex(@"\s*(?<abc>ABC)\s*|\s*(?<def>DEF)\s*");
        var data = new Dictionary<string, string>() { { "abc", "***" }, { "def", "xxx" } };
        var txt2 = rx.Replace(txt, (m) =>
        {
            var sb = new StringBuilder();
            var pos = m.Index;
            for (var idx = 1; idx < m.Groups.Count; idx++)
            {
                var group = m.Groups[idx];
                if (!group.Success)
                {
                    // ignore non-matching group
                    continue;
                }
                var name = rx.GroupNameFromNumber(idx);
                // append what's before
                sb.Append(txt.Substring(pos, group.Index - pos));
                string value = null;
                if (group.Success && data.TryGetValue(name, out value))
                {
                    // append dictionary value
                    sb.Append(value);
                }
                else
                {
                    // append group value
                    sb.Append(group.Value);
                }
                pos = group.Index + group.Length;
            }
            // append what's after
            sb.Append(txt.Substring(pos, m.Index + m.Length - pos));
            return sb.ToString();
        });
        Assert.AreEqual(exp, txt2);
    }
