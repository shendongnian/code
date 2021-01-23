            <ContentControl Content="{Binding SelectedViewItem}">
                <behavior:ContentControlBehavior.ContentChangedAnimation>
                    <Storyboard>
                        <ThicknessAnimation To="0" From="30,0,-30,0" Duration="0:0:0.3" Storyboard.TargetProperty="Margin"/>
                    </Storyboard>
                </behavior:ContentControlBehavior.ContentChangedAnimation>
            </ContentControl>
