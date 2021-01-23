        <TreeView Name="m_kTest">
            <TreeView.Resources>
                <HierarchicalDataTemplate x:Key="BoolDisplayTemplate" DataType="{x:Type self:BoolNode}" ItemsSource="{Binding Children}"> /*template*/ </HierarchicalDataTemplate>
                <HierarchicalDataTemplate x:Key="BoolEditTemplate" DataType="{x:Type self:BoolNode}" ItemsSource="{Binding Children}"> /*template*/ </HierarchicalDataTemplate>
                <HierarchicalDataTemplate x:Key="CompareEditTemplate"  DataType="{x:Type self:CompareNode}" ItemsSource="{Binding Children}"> /*template*/ </HierarchicalDataTemplate>
                <HierarchicalDataTemplate x:Key="CompareDisplayTemplate" DataType="{x:Type self:CompareNode}" ItemsSource="{Binding Children}"> /*template*/ </HierarchicalDataTemplate>
            
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
                <Style.Triggers>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding Path=IsBoolNode}" Value="True"/>
                            <Condition Binding="{Binding Path=IsSelected}" Value="False"/>
                        </MultiDataTrigger.Conditions>
                        <MultiDataTrigger.Setters>
                            <Setter Value="{StaticResource BoolDisplayTemplate}" Property="HeaderTemplate"/>
                        </MultiDataTrigger.Setters>
                    </MultiDataTrigger>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding Path=IsBoolNode}" Value="True"/>
                            <Condition Binding="{Binding Path=IsSelected}" Value="True"/>
                        </MultiDataTrigger.Conditions>
                        <MultiDataTrigger.Setters>
                            <Setter Value="{StaticResource BoolEditTemplate}" Property="HeaderTemplate"/>
                        </MultiDataTrigger.Setters>
                    </MultiDataTrigger>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding Path=IsBoolNode}" Value="False"/>
                            <Condition Binding="{Binding Path=IsSelected}" Value="False"/>
                        </MultiDataTrigger.Conditions>
                        <MultiDataTrigger.Setters>
                            <Setter Value="{StaticResource CompareDisplayTemplate}" Property="HeaderTemplate"/>
                        </MultiDataTrigger.Setters>
                    </MultiDataTrigger>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding Path=IsBoolNode}" Value="False"/>
                            <Condition Binding="{Binding Path=IsSelected}" Value="True"/>
                        </MultiDataTrigger.Conditions>
                        <MultiDataTrigger.Setters>
                            <Setter Value="{StaticResource CompareEditTemplate}" Property="HeaderTemplate"/>
                        </MultiDataTrigger.Setters>
                    </MultiDataTrigger>
                </Style.Triggers>
            </Style>
            </TreeView.Resources>
        </TreeView>
