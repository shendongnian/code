     foreach (var item in areaList)
    {
      using (Html.BeginForm())
      {
         <p>
            @Html.ActionLink(item.AreaName, //Title
                      "GetSoftware",        //ActionName
                        "Area",             // Controller name
                         new { AreaID= 0 }, //Route arguments
                            null           //htmlArguments,  which are none. You need this value
                                           //     otherwise you call the WRONG method ...
               );
        </p>
      }
    }
