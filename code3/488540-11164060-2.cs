    public List<int> SelectedPositionIDList
    {
       get
       {
            if(Session["SelectedPositions"] != null)
              return Session["SelectedPositions"] as List<int>;
            return new List<int>();
       }
       set
       {
          Session["SelectedPositions"] = value;
       }
    }
