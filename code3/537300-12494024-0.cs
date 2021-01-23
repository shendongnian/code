    VB:NET
    
               Private Function DoSomething(Of TEnum As {IComparable, IConvertible, IFormattable})(ByVal valueEnum As TEnum) As Int32
            
                  Dim i As Int32 = CInt(Convert.ChangeType(valueEnum, valueEnum.GetTypeCode()))
                  //Do something with int
                  i += 1
                  Return i
            
               End Function
            
        C#
                    
            private int DoSomething<TEnum>(TEnum valueEnum) where TEnum: IComparable, IConvertible, IFormattable 
                        {
                            int i = 0;
                            i = (int)Convert.ChangeType(valueEnum, valueEnum.GetTypeCode());
                            i++;
                            return i;
                        }
