    List<NewClass> = from x in GetListItemsBySystemResult 
                    select new NewClass{
                      Creation_DateTime = x.Creation_DateTime ,
                      ...,
                      ItemRequestStatus = "Value",
                      IsButtonEnabled = "Value",
                      };
