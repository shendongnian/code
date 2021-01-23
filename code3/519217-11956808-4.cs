    public class DummyClass : DependencyObject
    {
        public static readonly DependencyProperty TheOperatorProperty = DependencyProperty.RegisterAttached(
            "TheOperator", typeof(Operator), typeof(DummyClass),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender)
        );
        public static Operator GetTheOperator(DependencyObject elem) { return (Operator)elem.GetValue(TheOperatorProperty); }
        public static void SetTheOperator(DependencyObject elem, Operator value) { elem.SetValue(TheOperatorProperty, value); }
    }
        ... xmlns:myextra="clr-namespace:...." ....
    <Window.Resources>
        <myextra:OperatorPicker x:Key="conv1" />
    </Window.Resources>
    <Grid>
        <ListBox x:Name="lbxFirst" ItemsSource="{Binding ProfileUsers}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel x:Name="aparent" Orientation="Horizontal"
                                myextra:DummyClass.TheOperator="{Binding Path=., Converter={StaticResource conv1}}">
                        <TextBlock Margin="5" Text="{Binding User_ID}" />
                        <TextBlock Margin="5" Text="{Binding Login}" />
                        <TextBlock Margin="5" Text="{Binding Address}" />
                        <TextBlock Margin="5"
                                   Text="{Binding Path=(myextra:DummyClass.TheOperator).OperatorCodename, ElementName=aparent}" />
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
