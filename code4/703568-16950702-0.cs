    <Grid>
      <ContentPresenter Content="{Binding SomeProperty}">
         <ContentPresenter.ContentTemplate>
             <DataTemplate>
                 <!-- Here, the DataContext is SomeProperty, so you need to use a RelativeSource to reach the Grid's DataContext -->
                 <TextBox Text="{Binding DataContext.SomeGridViewModelProperty, RelativeSource={RelativeSource AncestorType=Grid}}"/>
             </DataTemplate>
         </ContentPresenter.ContentTemplate>
      </ContentPresenter>
    </Grid>
