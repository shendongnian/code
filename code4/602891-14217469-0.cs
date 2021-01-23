    private void AddData(object data) {
      // data would be what you would normally fill to the m_dataGrid.DataSource
      DataTable table = m_dataGrid.DataSource as DataTable;
      if (table == null) {
        DataView view = m_dataGrid.DataSource as DataView;
        if (view != null) {
          table = view.Table;
        }
      }
      if (table != null) {
        Sort(table);
      }
    }
