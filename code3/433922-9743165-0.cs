    <UserControl.Resources>
        <DataTemplate DataType="{x:Type ViewModel:DataItem}" x:Key="ItemTemplate">
            <ContentControl>
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="MouseDoubleClick">
                        <i:InvokeCommandAction Command="{Binding DoubleClickCommand}"/>
                    </i:EventTrigger>
                    <i:EventTrigger EventName="KeyUp">
                        <i:InvokeCommandAction Command="{Binding KeyUpCommand}"/>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
                <TextBox Text="{Binding Name}">
                </TextBox>
            </ContentControl>
        </DataTemplate>
    </UserControl.Resources>
    <ListBox x:Name="listBox" ItemTemplate="{StaticResource ItemTemplate}" ItemsSource={Binding Items} />
