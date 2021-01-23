    <Button Grid.Column="1" Content="..."  Name="ellipseButton" Click="ellipseButton_Click">
        <Button.ContextMenu>
           <ContextMenu >
              <ContextMenu.ItemTemplate>
                  <DataTemplate>
                       <TextBlock Text="{Binding}" />
                  </DataTemplate>
              </ContextMenu.ItemTemplate>
            </ContextMenu>
         </Button.ContextMenu>
    </Button>
