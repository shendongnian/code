    <ContentControl ...>
        <ContentControl.Template>
            <ControlTemplate TargetType="{x:Type ContentControl}">
                <Grid>
                    ...
                    <ContentPresenter Grid.Column="2" Name="PlaceHolder" 
                                      Content="{TemplateBinding Content}" />
                    ...
                </Grid>
            </ControlTemplate>
        </ContentControl.Template>
    </ContentControl>
