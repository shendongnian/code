    list.Sort((x,y) => {
      if(!x.Nullable.HasValue) {
         if(!y.Nullable.HasValue) return 0; // equal
         else return -1; // y is greater
      }
      else
      {
        if(!y.Nullable.HasValue) return 1; // x is greater
        if(x == y) return 0; // equal
        if(x < y) return -1; // y is greater
        else return 1;
      }
    }
