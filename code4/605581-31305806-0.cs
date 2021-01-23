    <DataTemplate.Triggers>
      <MultiDataTrigger>
        <MultiDataTrigger.Conditions>
          <Condition Binding="{Binding IsMouseOver, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ListBoxItem}}}" Value="True" />
          <Condition Binding="{Binding Type}" Value="{x:Static loc:AppProfileItemType.Custom}" />
        </MultiDataTrigger.Conditions>
        <MultiDataTrigger.Setters>
          <Setter TargetName="PART_Delete" Property="Visibility" Value="{x:Static Visibility.Visible}" />
        </MultiDataTrigger.Setters>
      </MultiDataTrigger>
    </DataTemplate.Triggers>
