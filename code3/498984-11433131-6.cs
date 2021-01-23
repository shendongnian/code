    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <view:MyDataUserControl DataContext="{Binding MyData}" Grid.Column="0"/>
        <view:MyMetaDataUserControl DataContext="{Binding MyMetaData}" Grid.Column="1"/>
        <Button Content="Save" Command="{Binding SaveCommand}" Grid.Column="2"/>
    </Grid>
