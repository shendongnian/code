     function gvValidate(rowIndex) {
    var grid = document.getElementById('<%= GridViewCTInformation.ClientID %>');
     if(grid!=null) {
         var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input"); 
        for(i = 0; i < Inputs.length; i++) 
         {
          if(Inputs[i].type == 'text' ) 
           {
                      if (Inputs[i].value == "") {
                         alert("Enter values,blank is not allowed");
                         return false;
                     }
                                                  
          }
         }
         return true;
     }
  }
    Protected Sub GridViewCTInformation_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewCTInformation.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim btnSave As Button = DirectCast(e.Row.FindControl("ButtonCTInfoSave"), Button)
                btnSave.Attributes.Add("onclick", "return gvValidate(" + e.Row.RowIndex.ToString() + ")")
            End If
        Catch ex As Exception
            Common.WriteLog(ex.Message)
            Common.WriteLog((ex.StackTrace))
            Response.Redirect("..\Errors.aspx", False)
        End Try
    End Sub
