     var selectByEnyCondition=(from c in ctx.customer ...);
     //---- you must add by below way : 
     if(!(String.IsNullOrEmpty(txtName.Text)))
     {
        selectByEnyCondition.Where(.....);
     }
     if(!String.IsNullOrEmpty(sex))
     {
      selectByEnyCondition= opportunites.Where(.....);
     }
     //------ 
     /* **** beacuse you use by ADO.NET technique you should use StringBuilder -->*/
      StringBuilder query;
      query.add("SELECT * FROM BankTbl WHERE ");
    
      if(!(String.IsNullOrEmpty(txtName.Text))){ 
       query.Add("Name Like {0}",txtName.Text); 
      
      //-----now continue for build your criteria 
  
