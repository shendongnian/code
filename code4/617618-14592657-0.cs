    <Button Grid.Column="1" Content="..."  Click="Button_Click">
        <Button.ContextMenu>
            <ContextMenu DataContext="{Binding RelativeSource={RelativeSource Self}, Path=PlacementTarget.DataContext}" 
                         ItemsSource="{Binding Path=SelectableDescriptions}" >    
                <TextBlock Text="{Binding}"/>
            </ContextMenu>
        </Button.ContextMenu>        
    </Button>
