    <Grid>
		<Grid.DataContext>
			<XmlDataProvider Source="DataBase.xml"/>
		</Grid.DataContext>
		<StackPanel>
			<ComboBox ItemsSource="{Binding XPath=/DBRoot/Mfg}" Name="comboBox" SelectedIndex="0">
				<ComboBox.ItemTemplate>
					<DataTemplate>
						<TextBlock Text="{Binding XPath=@name}"/>
					</DataTemplate>
				</ComboBox.ItemTemplate>
			</ComboBox>
			<DataGrid ItemsSource="{Binding ElementName=comboBox, Path=SelectedItem}" AutoGenerateColumns="False">
				<DataGrid.Columns>
					<DataGridTextColumn Binding="{Binding XPath=Nominal}" Header="Nominal"/>
					<DataGridTextColumn Binding="{Binding XPath=Schedule}" Header="Schedule"/>
					<DataGridTextColumn Binding="{Binding XPath=OD}" Header="OD"/>
					<DataGridTextColumn Binding="{Binding XPath=Wall_Thickness}" Header="Wall Thickness"/>
					<DataGridTextColumn Binding="{Binding XPath=ID}" Header="ID"/>
				</DataGrid.Columns>
			</DataGrid>
		</StackPanel>
	</Grid>
