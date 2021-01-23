    <ListView Name="lstView" ItemsSource="{Binding Path=SimResults}" >
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="SelectionChanged">
                <i:InvokeCommandAction Command="{Binding SelectedItemCommand}" CommandParameter="{Binding SelectedItem, ElementName=lstView}" />
            </i:EventTrigger>
        </i:Interaction.Triggers>
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="HorizontalContentAlignment" Value="Center"/>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.View>
            <GridView>
                <GridView.Columns>
                    <GridViewColumn Header="FileUniqueID" Width="Auto" DisplayMemberBinding="{Binding Path=FileUniqueID}" />
                    <GridViewColumn Header="XML" Width="Auto" DisplayMemberBinding="{Binding Path=XML}" />
                    <GridViewColumn Header="Request" Width="Auto" HeaderStringFormat="" DisplayMemberBinding="{Binding Path=RequestShort}" />
                    <GridViewColumn Header="RequestDate" Width="Auto" DisplayMemberBinding="{Binding Path=RequestDate}" />
                    <GridViewColumn Header="Response" Width="Auto" DisplayMemberBinding="{Binding Path=ResponseShort}" />
                    <GridViewColumn Header="ResponseDate" Width="Auto" DisplayMemberBinding="{Binding Path=ResponseDate}" />
                    <GridViewColumn Header="ResendCounter" Width="Auto" DisplayMemberBinding="{Binding Path=ResendCounter}" />
                </GridView.Columns>
            </GridView>
        </ListView.View>
    </ListView>
