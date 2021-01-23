    public static List<OnderzoekColumn> GetOnderzoekColumns(int onderzoekId)
    {
      var store = typeof(OnderzoekColumn).GetStore();
      var columns = store.Items<OnderzoekColumn>().Where(c => c.OnderzoekId == onderzoekId);
      return columns.ToList();
    }
