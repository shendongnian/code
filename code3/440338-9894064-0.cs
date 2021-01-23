    try
    {
       // ...
       SqlCommand.ExecuteNonQuery( ... );
    }
    catch( SqlException SqlEx )
    {
      string errMsg = String.Empty;
      switch(SqlEx.number)
      {
         case 100:
           errMsg = "blah blah blah";
           break;
         case 200:
           errMsg = "blah blah blah";
           break;
         case 300:
           errMsg = "blah blah blah";
           break;
         
      }
      if(!String.IsNullOrEmpty(errMsg))
      {
         //If you want a pop up display message
         MessageBox.Show( errMsg );
     
         //If you want to display it on a label of a form
         Form1.Labelx.text = errMsg;
      }
    }
