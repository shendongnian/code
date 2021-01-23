    public class LineViewModel
    {
       public bool IsChecked
       {
         get { return _isChecked;
       }
       set
       {
       // do something here
       }
    }
    <GridViewColumn.CellTemplate>
        <DataTemplate>
            <CheckBox IsChecked="{Binding IsChecked, Mode=TwoWay}" IsThreeState="False"/>
        </DataTemplate>
    </GridViewColumn.CellTemplate>
