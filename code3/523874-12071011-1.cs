         // In converter class
         public object Convert(object value, ...)
         {
              var input = (string)value;
              return String.IsNullOrWhiteSpace(input);
         }
    <!---->
         <!--Resources-->
         <vc:IsNullOrWhiteSpaceConverter x:Key="NWSConv" />
    <!---->
         <DataTrigger Binding="{Binding Text,
                                        ElementName=val_Name,
                                        Converter={StaticResource NWSConv}}"
                      Value="false">
         
