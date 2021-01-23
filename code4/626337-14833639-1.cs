    <FlowDocumentScrollViewer>
      <FlowDocumentScrollViewer.Resources>
        <DataTemplate DataType="{x:Type system:Int32}">
          <TextBlock Text="{Binding StringFormat='A number: {0}'}" />
        </DataTemplate>
        <DataTemplate DataType="{x:Type system:Boolean}">
          <TextBlock Text="{Binding StringFormat='A bool: {0}'}" />
        </DataTemplate>
      </FlowDocumentScrollViewer.Resources>
      <FlowDocument>
        <Table BorderBrush="Black"
               BorderThickness="1"
               CellSpacing="0">
          <Table.Columns>
            <TableColumn></TableColumn>
            <TableColumn></TableColumn>
            <TableColumn></TableColumn>
            <TableColumn></TableColumn>
          </Table.Columns>
          <Table.RowGroups>
            <TableRowGroup>
              <TableRow>
                <TableCell>
                  <BlockUIContainer>
                    <ContentControl Content="{Binding MixedTypeList[0]}" />
                  </BlockUIContainer>
                </TableCell>
                <TableCell>
                  <BlockUIContainer>
                    <ContentControl Content="{Binding MixedTypeList[1]}" />
                  </BlockUIContainer>
                </TableCell>
                <TableCell>
                  <BlockUIContainer>
                    <ContentControl Content="{Binding MixedTypeList[2]}" />
                  </BlockUIContainer>
                </TableCell>
              </TableRow>
            </TableRowGroup>
          </Table.RowGroups>
        </Table>
      </FlowDocument>
    </FlowDocumentScrollViewer>
