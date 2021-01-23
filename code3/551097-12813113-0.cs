         <DataTemplate >
                <Grid>
                    <Grid.ColumnDefinitions>
                         <ColumnDefinition />
                         <ColumnDefinition />
                         <ColumnDefinition />
                    </Grid.ColumnDefinitions>
  
                    <Label Grid.Column="0" Content="{Binding Path=ChanelName}" />
                    <TextBox Grid.Column="1" Text="{Binding Path=VoltageText}" />
                    <Button Grid.Column="2" Command="{Binding ElementName=myViewChannelList, Path=DataContext.SetCommand}" />
                </Grid>
            </DataTemplate>
   
