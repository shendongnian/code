    <Button>
            <Button.Content>
                <x:Type TypeName="Visual"/>
            </Button.Content>
            <Button.Template>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Grid>
                        <ContentPresenter ContentSource="Content"/>
                    </Grid>
                </ControlTemplate>
            </Button.Template>
            <Button.ContentTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Path=Name}"/>
                </DataTemplate>
            </Button.ContentTemplate>
        </Button>
