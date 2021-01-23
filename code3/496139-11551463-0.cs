    public class dal
    {
      public tw_main getSelectedValue(pass the parameters required by the method)
      {
        //your connection and query code
        var twmain = new tw_main();
        twmain.SchemaCode =  ds.Tables[0].Rows[0]["schm_code"].ToString(); 
        return twmain;
      }
    }
