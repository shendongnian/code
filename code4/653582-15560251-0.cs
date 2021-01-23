    <TabControl>
        <TabControl.Resources>
            <DataTemplate x:Key="TabTemplate">
                <Label Content="Name" Name="label1" />                
            </DataTemplate>
        </TabControl.Resources>
        <TabItem Header="Add" Name="tabItem1">
            <TabItem.ContentTemplate>
                <DataTemplate>
                    <Grid Height="213">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*"/>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>
                        <Button Content="Add" Name="button1" />
                        <ContentPresenter Grid.Row="1" ContentTemplate="{StaticResource TabTemplate}"/>
                    </Grid>
                </DataTemplate>
            </TabItem.ContentTemplate>
        </TabItem>
        <TabItem Header="Edit" Name="tabItem2">
            <TabItem.ContentTemplate>
                <DataTemplate>
                    <Grid Height="213">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*"/>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>
                        <Button Content="Edit" Name="button2" />
                        <ContentPresenter Grid.Row="1" ContentTemplate="{StaticResource TabTemplate}"/>
                    </Grid>
                </DataTemplate>
            </TabItem.ContentTemplate>
        </TabItem>
