    'VB.NET
       Private Function DoSomething(Of TEnum As {IComparable, IConvertible, IFormattable})(ByVal arvo As TEnum) As Int32
    
          Dim i As Int32 = CInt(Convert.ChangeType(arvo, arvo.GetTypeCode()))
          'Do something with int
          i += 1
          Return i
    
       End Function
    
    'C#
            private int DoSomething<TEnum>(TEnum value) where TEnum: IComparable, IConvertible, IFormattable 
            {
                int i = 0;
                i = (int)Convert.ChangeType(value, value.GetTypeCode());
                i++;
                return i;
            }
