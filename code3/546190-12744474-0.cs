    <DataGridTemplateColumn>
       <DataGridTemplateColumn.CellTemplate>
          <DataTemplate>
              <Button Content="Remove" Command="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type TabControl}}, Path=DataContext.BottomDetailVM.DeleteCommand}" Visibility="{Binding IsNew, Converter={StaticResource Bool2VisibilityConverter}, FallbackValue=Collapsed}" CommandParameter="{Binding}" />
          </DataTemplate>
       </DataGridTemplateColumn.CellTemplate>
    </DataGridTemplateColumn>
