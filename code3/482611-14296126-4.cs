    <phone:PhoneApplicationPage
        <!-- the usual xmlns attributes -->
        xmlns:vm="clr-namespace:MyApplication.Presentation.ViewModels"
        xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity">
        <phone:PhoneApplicationPage.DataContext>
            <vm:MyPageViewModel />
        </phone:PhoneApplicationPage.DataContext>
        <toolkit:MultiselectList x:Name="selectionlist" ItemsSource="{Binding Items}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="SelectionChanged">
                    <i:InvokeCommandAction
                       Command="{Binding UpdateSelectedCommand}"
                       CommandParameter="{Binding ElementName=selectionlist, Path=SelectedItems}"/>
                </i:EventTrigger>
                <i:EventTrigger EventName="Loaded">
                    <i:InvokeCommandAction
                       Command="{Binding LoadCommand}"
                       CommandParameter="{Binding ElementName='selectionlist'}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
            <toolkit:MultiselectList.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Name}"/>
                </DataTemplate>
            </toolkit:MultiselectList.ItemTemplate>
        </toolkit:MultiselectList>
    </phone:PhoneApplicationPage>
