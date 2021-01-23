    public EventList List
    {
      get { return m_List.Items; }
      set
      {
          //m_List.ListChanged -= List_ListChanged;
          m_List.Items = value;
          //m_List.ListChanged += List_ListChanged;
          //List_ListChanged();
      }
    }
