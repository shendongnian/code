        <DataTemplate DataType="{x:Type Local:MyDataViewmodel}">
            <view:MyDataUserControl/>
        </DataTemplate>
        <DataTemplate DataType="{x:Type Local:MyMetaDataViewmodel}">
            <view:MyMetaDataUserControl/>
        </DataTemplate>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <ContentPresenter Content="{Binding MyData}" Grid.Column="0"/>
        <ContentPresenter Content="{Binding MyMetaData}" Grid.Column="1"/>
        <Button Content="Save" Command="{Binding SaveCommand}" Grid.Column="2"/>
    </Grid>
