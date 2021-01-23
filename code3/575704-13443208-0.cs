    class MyButtonInfo
    {
    	public ImageSource Icon{get;set;}
    	public string Caption{get;set;}
    	public Command Command{get;set;}
    }
    
    <DataTemplate x:Key="MyTemplate">
    	<StackPanel>
    		<Image Source="{Binding Icon}"/>
    		<TextBlock Text="{Binding Caption}"/>
    	</StackPanel>
    </DataTemplate>
    
    <Button Content="{Binding ButtonInfo}" ContentTemplate="{StaticResource MyTemplate}" Command="{Binding Command}">
    </Button>
