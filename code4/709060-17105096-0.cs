      void Page_Load(object sender, EventArgs e)
      {
        if (ViewState["arrayListInViewState"] != null)
        {
          PageArrayList = (ArrayList)ViewState["arrayListInViewState"];
        }
        else
        {
          // ArrayList isn't in view state, so we need to create it from scratch.
          PageArrayList = CreateArray();
        }
        // Code that uses PageArrayList.
      }
