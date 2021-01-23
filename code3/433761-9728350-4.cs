    var MyGridDtoCollection = ConvertTextDtoToGridDtos(result.Elements);
    resultGrid.ItemsSource = MyGridDtoCollection;
        Action a = ( ) =>
          {
            foreach ( var gridDto in MyGridDtoCollection )
            {
              gridDto.ValidationBrush = Brushes.Black;
              System.Threading.Thread.Sleep( 500 );
            }
          };
          a.BeginInvoke( result =>
         {
           a.EndInvoke( result );
         } , a );
