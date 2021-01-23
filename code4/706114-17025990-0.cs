    private List<Asset> m_list;
    private Asset[] GetPropertyInfo(string name) {
      var items = m_list.Where(a => a.Name == name);
      if (items != null) {
        return items.ToArray();
      } else {
        return null;
      }
    }
