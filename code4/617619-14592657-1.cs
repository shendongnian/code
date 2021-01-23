    <Button Grid.Column="1" Content="..."  Click="Button_Click">
        <Button.ContextMenu>
            <ContextMenu DataContext="{Binding RelativeSource={RelativeSource Self}, Path=PlacementTarget.DataContext}" 
                         ItemsSource="{Binding Path=SelectableDescriptions}" >    
                <ContextMenu.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Path=SomePropertyOnItem}" />
                    </DataTemplate>
                </ContextMenu.ItemTemplate>                            
            </ContextMenu>
        </Button.ContextMenu>        
    </Button>
