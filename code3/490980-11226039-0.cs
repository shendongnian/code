    public class MyDataSource
    {
    	public IEnumerable<string> ComboItems 
    	{
    		return new string[] { "Test 1", "Test 2" };
    	}
    }
    
    <ComboBox
        Height="23" Name="status"
        IsReadOnly="False"
        ItemsSource="{Binding Path=ComboItems}"
        Width="120">
    </ComboBox>
