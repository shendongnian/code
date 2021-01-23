    <UserControl ...>
        <UserControl.ContentTemplate>
            <DataTemplate>
                <Grid>
                    ...
                    <Canvas>
                        <ContentPresenter Content="{TemplateBinding Content}"/>
                    </Canvas>
                    ...
                </Grid>
            </DataTemplate>
        </UserControl.ContentTemplate>
    </UserControl>
