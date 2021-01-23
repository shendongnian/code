    <MyOwn:CustomDataGridColumn Header="Column1Header" Name="Column1" ElementStyle="{StaticResource ElementStyleWithMultiConverterAndTriggers}">
        <MyOwn:CustomDataGridColumn.Binding>
            <Binding Path="RowModel.ColumnName"  ValidatesOnDataErrors="True" >
                <Binding.ValidationRules>
                    <Validators:CustomCellDataInfoValidationRule />
                        </Binding.ValidationRules>
                </Binding>
        </MyOwn:CustomDataGridColumn.Binding>
    </MyOwn:CustomDataGridColumn>
	
