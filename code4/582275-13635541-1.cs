    <UserControl>
        <Grid>
            <TextBox>Hello World</TextBox>
            <Border Background="#AAFFFFFF"> <!-- Semitransparent overlay -->
                <ProgressBar IsIndeterminate="true" Visibility="{Binding IsBusy, Converter={StaticResource BooleanToVisibilityConverter}" />
            </Border>
        </Grid>
    </UserControl>
