    <DataGridTextColumn Binding="{Binding Column1ViewModelProperty }"/>
    //Code behind
    public string Column1ViewModelProperty {
      get{
        return _column1ViewModelProperty;
      }
      set{
        _column1ViewModelProperty = value;
        Column2ViewMOdelProperty = calculatedValue;
        OnPropertyChanged("Column1ViewModelProperty");
      }
    }
    public string Column2ViewModelProperty {
      get{
        return _column2ViewModelProperty;
      }
      set{
        _column2ViewModelProperty = value;
        OnPropertyChanged("Column2ViewModelProperty");
      }
    }
