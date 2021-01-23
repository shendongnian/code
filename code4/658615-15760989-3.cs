    <TreeView ItemsSource="{Binding ...}">
        <TreeView.Resources>
            <HierarchicalDataTemplate DataType="TypeHoldingCustomersCollection" 
                ItemsSource="{Binding Customers}">
                <TextBlock Text="Customers"/>
            </HierarchicalDataTemplate>
    
            <HierarchicalDataTemplate DataType="CustomerViewModel" 
                ItemsSource="{Binding Commands}">
                <TextBlock Text="{Binding Path=Customer.Name}"/>
            </HierarchicalDataTemplate>
    
            <DataTemplate DataType="CommandWrapper">
                <Button Content="{Binding CommandName}" Command="{Binding Command}"/>
            </DataTemplate>
        </TreeView.Resources>
    </TreeView>
