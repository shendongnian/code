     <UserControl xmlns:local="clr-namespace:MyWpfApplication1.MyTest.ViewModels" 
                  xmlns:views="clr-namespace:MyWpfApplication1.Controls.Views" 
        <ItemsControl ItemsSource="{Binding ScreenViewModelCollection}">
            <ItemsControl.Resources>
                <DataTemplate DataType="{x:Type local:RedScreenViewModel}">
                    <Grid>
                        <views:RedScreenView/>
                    </Grid>
                </DataTemplate>
                <DataTemplate DataType="{x:Type local:GreenScreenViewModel}">
                    <Grid>
                        <views:GreenScreenView/>
                    </Grid>
                </DataTemplate>
            </ItemsControl.Resources>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <ContentPresenter Content="{Binding}"/>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
