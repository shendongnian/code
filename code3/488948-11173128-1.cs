    <DataGridTemplateColumn Header="Website" 
            IsReadOnly="True" SortMemberPath="Input.OriginalUri.AbsoluteUri" >
        <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
               <Button Content="{Binding Website}" Command="{StaticResource NavigateCommand}" CommandParameter="{Binding Website}" Style={StaticResource LinkStyle}"/>
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
    </DataGridTemplateColumn>
