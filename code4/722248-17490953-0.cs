    <Button>
    	<Button.ContextMenu >
    		<ContextMenu DataContext="{Binding}" ItemsSource="{Binding Path=Commands}">
    			<ContextMenu.ItemTemplate>
    				<DataTemplate>
    					<MenuItem Header="{Binding Path=Title}" Command="{Binding Path=Command}" />
    				</DataTemplate>
    			</ContextMenu.ItemTemplate>
    		</ContextMenu>
    	</Button.ContextMenu>
    </Button>
