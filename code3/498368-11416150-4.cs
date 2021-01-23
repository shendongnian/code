objCommand.CommandText = "INSERT INTO Product " +
   "(CustomerName,CustomerAddress,InvoiceNumber,InvoiceDate,ProductName,"+  
   "ProductDescription,UnitCost,Quantity,TotalAmountToBePaid) VALUES " + 
   "(@cname, @caddress, @inumber, @idate, @pname, @pdesc, @unitcost, @qty, @total); " +
   "SELECT SCOPE_IDENITY();";
objCommand.Parameters.Add(new SqlParameter("@cname", tbcustomername.Text));
objCommand.Parameters.Add(new SqlParameter("@caddress", tbcustomeraddress.Text));
objCommand.Parameters.Add(new SqlParameter("@inumber", int.Parse(tbinvoicenumber.Text)));
objCommand.Parameters.Add(new SqlParameter("@idate", DateTime.Parse(tbinvoicedate.Text)));
objCommand.Parameters.Add(new SqlParameter("@pname", tbproductname.Text));
objCommand.Parameters.Add(new SqlParameter("@pdesc", tbproductdescription.Text));
objCommand.Parameters.Add(new SqlParameter("@unitcost", decimal.Parse(tbunitcost.Text)));
objCommand.Parameters.Add(new SqlParameter("@qty", int.Parse(tbquantity.Text)));
objCommand.Parameters.Add(new SqlParameter("@total", decimal.Parse(tbamounttobepaid.Text)));
int id = (int)objCommand.ExecuteScalar(); 
 
