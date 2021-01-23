    <telerik:RadGridView x:Name="radGridView" 
                              AutoGenerateColumns="False">
	<telerik:RadGridView.Columns>
	   <telerik:GridViewDataColumn DataMemberBinding="{Binding Name}" Header="Parameter" />
	   <telerik:GridViewDataColumn DataMemberBinding="{Binding Value}" Header="Value">
		  <telerik:GridViewDataColumn.CellTemplateSelector>
			 <telerik:ConditionalDataTemplateSelector>
				<telerik:DataTemplateRule Condition="PropertyId &lt; 1">
				   <DataTemplate>
					  <TextBox Text="{Binding Value, StringFormat=c}"/>
				   </DataTemplate>
				</telerik:DataTemplateRule>
				<telerik:DataTemplateRule Condition="PropertyId > 0">
				   <DataTemplate>
					  <CheckBox IsChecked="{Binding Value}" />
				   </DataTemplate>
				</telerik:DataTemplateRule>
			 </telerik:ConditionalDataTemplateSelector>
		  </telerik:GridViewDataColumn.CellTemplateSelector>
	   </telerik:GridViewDataColumn>
	</telerik:RadGridView.Columns>
