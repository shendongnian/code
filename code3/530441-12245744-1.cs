    public class Person
    {
        // properties
        public string Name { .... }
        public string Surname { ... }
        public List<Person> Subordinates { .... }
    }
    <StackPanel Orientation="Horizontal">
        <TreeView x:Name="twi">
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding Subordinates}">
                    <TextBlock>
                        <Run Text="{Binding Name}" />
                        <Run Text=" " />
                        <Run Text="{Binding Surname}" />
                    </TextBlock>
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
        <StackPanel Orientation="Vertical">
            <TextBlock Text="The selected person:" />
            <TextBox Text="{Binding ElementName=twi, Path=SelectedItem.Name, Mode=TwoWay}" />
            <TextBox Text="{Binding ElementName=twi, Path=SelectedItem.Surname, Mode=TwoWay}" />
        </StackPanel>
    </StackPanel>
