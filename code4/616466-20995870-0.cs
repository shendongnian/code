          public static decimal opcomm { get; set; }
          public static decimal opcommPercentage { get; set; }
          public static void SetOpCommission()
          {
              using (DataBaseClass dataclass = new DataBaseClass())
              {
                  dataclass.Connect();
                  string sql = @"SELECT  EmployeeComission, EmployeeComissionPercentage,MobileKindId,Id,StartDate FROM EmployeeCommission";
                 
                  opcomm = (decimal)dataclass.ExecuteScalar(sql);
                  opcommPercentage = (decimal)dataclass.ExecuteScalar(sql);
              }
          }
