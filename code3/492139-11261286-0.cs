    Class Region
    {
     //...
     public bool IsChecked {get; set;}
     //...
    }
    <CheckBox Content="{Binding Path=RegionName}"
                      Tag="{Binding Path=RegionID}"
                      IsChecked="{Binding Path=IsChecked}"
                      Click="CheckBox_Click"/>
