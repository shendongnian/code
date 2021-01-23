    <ItemsControl ItemsSource="{Binding Documents}">
	<ItemsControl.ItemTemplate>
		<DataTemplate>
			<StackPanel>
				<Label Content="{Binding Path=Attribute.Path}"/>
					<ItemsControl ItemsSource="{Binding Pages}">
						<ItemsControl.ItemTemplate>
							<DataTemplate>
								<StackPanel>
								
    
	<Label Content="{Binding Index}"/>
                                    <Button Content="{Binding Content}"
											Command="{x:Static viewModel:DocViewModel.Tests }" 
                                            CommandParameter="{Binding Path=DataContext.Attribute.Path,RelativeSource={RelativeSource AncestorType=ContentPresenter, Mode=FindAncestor,AncestorLevel=2"/> 
                                </StackPanel>
							</DataTemplate>
						</ItemsControl.ItemTemplate>
					</ItemsControl>
				</StackPanel>
			</DataTemplate>
		</ItemsControl.ItemTemplate>
