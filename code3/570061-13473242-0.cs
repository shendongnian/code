            <ContentPresenter Grid.Column="2" Content="{Binding ElementName=myTreeView, Path=SelectedItem}">
                <ContentPresenter.Resources>
                    <DataTemplate DataType="{x:Type local:L1ViewModel}">
                        <StackPanel>
                            <TextBlock Text="{Binding Name}" />
                        </StackPanel>
                    </DataTemplate>
                    <DataTemplate DataType="{x:Type local:CategoryViewModel}">
                        <StackPanel>
                            <TextBlock Text="{Binding Name}" />
                        </StackPanel>
                    </DataTemplate>
                    <DataTemplate DataType="{x:Type local:L3ViewModel}">
                        <StackPanel>
                            <TextBlock Text="{Binding Name}" />
                        </StackPanel>
                    </DataTemplate>
                    <DataTemplate DataType="{x:Type local:L4ViewModel}">
                        <StackPanel>
                             <TextBox Text="{Binding Parent.Name}" />
                            <TextBlock Text="{Binding Name}" />
                        </StackPanel>
                    </DataTemplate>
                </ContentPresenter.Resources>
              </ContentPresenter>
