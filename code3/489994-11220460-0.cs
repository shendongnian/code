    if(Ds_Themes != null) {
     if( Ds_Themes.Tables != null) {
        if( Ds_Themes.Tables.Size() > 0) {
           if(Ds_Themes.Tables(0).Rows != null) {
             if(Ds_Themes.Tables(0).Rows.Size() > 0) {
              ThemeID = Ds_Themes.Tables(0).Rows(0)("ThemeID")
             }
           }
        }
      }
    }
