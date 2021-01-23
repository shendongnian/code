    public class valueAllocation
    {
        public int MyValue
        {
           get
           {
              if(this.ViewState["c"] != null) 
                   return int.Parse(this.ViewState["c"].ToString());
              return 0;
          }
          set
          {
              this.ViewState["c"] = value;
          }
        }
    }
