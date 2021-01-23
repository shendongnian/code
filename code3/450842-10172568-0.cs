     void Main()
        {
        DataTable dt = new DataTable();
        	if (dt.Columns.Count == 0)
        			{
        				dt.Columns.Clear();
        				dt.Columns.AddRange(
        					new DataColumn[] 
        					{
        						new DataColumn("TStamp", typeof(DateTime)),
        						new DataColumn("C1", typeof(double)),
        						new DataColumn("C2", typeof(double)),
        						new DataColumn("C3", typeof(double))
        						//new DataColumn("Unit", typeof(string))
        					}
        					);
        			}
        			
        			  Random ovValue = new Random();
        			for (int i = 0; i < 10; i++)
        			{
        				DataRow dnew = dt.NewRow();
        				dnew["TStamp"] = DateTime.Now.AddMonths(i);
        				dnew["C1"] = ovValue.Next(1, 100);
        				dnew["C2"] = ovValue.Next(1, 100);
        				dnew["C3"] = ovValue.Next(1, 100);
        				dt.Rows.Add(dnew);
        			}
        			try
        			{
        			int numberOfRecord = 100;
        			int count = dt.Rows.Count;	
        			if(numberOfRecord <= count)
        			{
        			dt = dt.DefaultView.ToTable().Rows.Cast<DataRow>().Take(numberOfRecord).CopyToDataTable();
        			}
        			else
        			{
        			/// No Erroe cause if you select more tested at LinqPad
        			dt = dt.DefaultView.ToTable().Rows.Cast<DataRow>().Take(100).CopyToDataTable();
        			}
        			}
        			catch(Exception ex)
        			{
        			Console.WriteLine("Error");
        			}
         
         foreach(DataRow r in dt.Rows)
         {
         Console.WriteLine(r["TStamp"].ToString());
         }
        
        }
