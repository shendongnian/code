    public bool IsQuantityLessThanTen
    {
       get
       {
          return Quantity < 10;
       }
    }
    <DataGrid>
      <DataGrid.Resources>
         <Style TargetType="DataGridRow">
            <ControlTemplate.Triggers>
               <DataTrigger Binding="{Binding IsQuantityLessThanTen}" Value="True">
                  <Setter Property="Background" Value="Red" />
               </DataTrigger>
            </ControlTemplate.Triggers>
         </Style>
      </DataGrid.Resources>
    ......
    </DataGrid>
