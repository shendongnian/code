	<DataGrid ItemsSource="{Binding CandidateList}">
		<DataGrid.Columns>
			<DataGridTextColumn Header="Id" Binding="{Binding CandidateID}"/>
			<DataGridTextColumn Header="RegNr" Binding="{Binding RegisterNo}"/>
			<DataGridTextColumn Header="Name" Binding="{Binding CandidateName}"/>
			<DataGridTemplateColumn>
				<DataGridTemplateColumn.Header>
					<CheckBox Checked="CheckBox_Checked" Unchecked="CheckBox_Checked"></CheckBox>
				</DataGridTemplateColumn.Header>
				<DataGridTemplateColumn.CellTemplate >
					<DataTemplate>
						<CheckBox IsChecked="{Binding BooleanFlag}"/>
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
			</DataGridTemplateColumn>
		</DataGrid.Columns>
	</DataGrid>
