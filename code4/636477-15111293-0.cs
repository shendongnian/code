     public static  class DerivedValues
     {
         public static void ToCustomerTypes(this CustomerDTO dto)
         {
                 if (dto.CustType == 1)
                 dto.GetCustomerTypes = "Special Customer";
         }
     }
