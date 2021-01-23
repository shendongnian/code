    <Page xmlns:common="using:MyApp.Common">
        <Page.Resources>
            <common:BooleanToVisibilityConverter x:Key="BoolToVisibilityConverter" />
        </Page.Resources>
        <Grid>
            <Grid Visibility="{Binding Configuration.IsCompleted, Converter={StaticResource BoolToVisibilityConverter}">
                <!-- put your actual view here -->
            </Grid>
            <Grid Visibility="{Binding Configuration.IsNotCompleted, Converter={StaticResource BoolToVisibilityConverter}">
                <!-- put your splash screen view here -->
            </Grid>
        </Grid>
    </Page>
