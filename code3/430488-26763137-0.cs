    [ValueConversion( typeof( string ), typeof( ProcessingState ) )]
    public class IntegerStringToProcessingStateConverter : IValueConverter
    {
     object IValueConverter.Convert( 
        object value, Type targetType, object parameter, CultureInfo culture )
     {
      int state;
      bool numeric = Int32.TryParse( value as string, out state );
      Debug.Assert( numeric, "value should be a String which contains a number" );
      Debug.Assert( targetType.IsAssignableFrom( typeof( ProcessingState ) ), 
        "targetType should be ProcessingState" ); 
    
      switch( state )
      {
       case -1:
        return ProcessingState.Complete; 
       case 0:
        return ProcessingState.Pending; 
       case +1:
        return ProcessingState.Active;
      }
      return ProcessingState.Unknown;
     } 
    
     object IValueConverter.ConvertBack( 
        object value, Type targetType, object parameter, CultureInfo culture )
     {
      throw new NotSupportedException( "ConvertBack not supported." );
     }
    }
    // *************************************************************
    [ValueConversion( typeof( ProcessingState ), typeof( Color ) )]
    public class ProcessingStateToColorConverter : IValueConverter
    {
     object IValueConverter.Convert( 
        object value, Type targetType, object parameter, CultureInfo culture )
     {
      Debug.Assert(value is ProcessingState, "value should be a ProcessingState");
      Debug.Assert( targetType == typeof( Color ), "targetType should be Color" );
     
      switch( (ProcessingState)value )
      {
       case ProcessingState.Pending:
        return Colors.Red; 
       case ProcessingState.Complete:
        return Colors.Gold; 
       case ProcessingState.Active:
        return Colors.Green;
      }
      return Colors.Transparent;
     } 
    
     object IValueConverter.ConvertBack( 
        object value, Type targetType, object parameter, CultureInfo culture )
     {
      throw new NotSupportedException( "ConvertBack not supported." );
     }
    } 
    object IValueConverter.Convert( 
        object value, Type targetType, object parameter, CultureInfo culture )
    {
     object output = value; 
     for( int i = 0; i < this.Converters.Count; ++i )
     {
      IValueConverter converter = this.Converters[i];
      Type currentTargetType = this.GetTargetType( i, targetType, true );
      output = converter.Convert( output, currentTargetType, parameter, culture );
     
      // If the converter returns 'DoNothing' 
      // then the binding operation should terminate.
      if( output == Binding.DoNothing )
       break;
     } 
     return output;
    }
    //***********Usage in XAML*************
        <!-- Converts the Status attribute text to a Color -->
        <local:ValueConverterGroup x:Key="statusForegroundGroup">
              <local:IntegerStringToProcessingStateConverter  />
              <local:ProcessingStateToColorConverter />
        </local:ValueConverterGroup>
