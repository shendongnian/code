    <Button>
        <Button.ContentTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="1*"></ColumnDefinition>
                        <ColumnDefinition Width="3*"></ColumnDefinition>
                    </Grid.ColumnDefinitions>
    
                    <Label Grid.Column="0" name="lblShortcut" Content="{Binding Shortcut }"/>
                    <Label Grid.Column="1" name="lblText" Content="{Binding Text}"/>
                </Grid>
            
            </DataTemplate>
        </Button.ContentTemplate>
    </Button>
