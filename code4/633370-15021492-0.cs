    <ItemsControl ItemsSource="{Binding }" AlterationCount={Binding CountOfItems}">
    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <Grid>
                // column definitions
                <Label Content="{Binding RelativeSource={RelativeSource
                       Mode=TemplatedParent}, 
                       Path=(ItemsControl.AlternationIndex)}"/>
                // some other controls
            </Grid>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
