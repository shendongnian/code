    IList<string> strs = nodes.Select(tr => tr.Elements("td")).Select(td => td.InnerText.TrimEnd()).ToList();
    var ints = strs.Select(str => str.TryGetInt()).Where(i => i.HasValue).Select(i => i.Value);
    strs.Add((ints[0] * [ints[1]).ToString());
    public static class Extensions
    {
      public static int? TryGetInt(this string item)
      {
        int i;
        bool success = int.TryParse(item, out i);
        return success ? (int?)i : (int?)null;
      }
    }
