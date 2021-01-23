    <DataGrid DataContext="{StaticResource ResourceKey=AllUsers}" ItemsSource="{Binding}" AutoGenerateColumns="False">
            <DataGrid.Columns>
			<DataGridTextColumn Binding="{Binding GivenName}" />
			<DataGridTextColumn Binding="{Binding Surname}" />
			<DataGridTemplateColumn>
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<ItemsControl ItemsSource="{Binding ApplicationRoles}">
							<ItemsControl.ItemTemplate>
								<DataTemplate>
									<CheckBox Content="{Binding RoleName}" IsChecked="{Binding IsMember, Mode=TwoWay}" />
								</DataTemplate>
							</ItemsControl.ItemTemplate>
						</ItemsControl>
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
			</DataGridTemplateColumn>
		</DataGrid.Columns>
	</DataGrid>
