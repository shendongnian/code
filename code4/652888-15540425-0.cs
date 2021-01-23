    <Page.Resources>
        <Storyboard x:Name="ballstoryleft">
            <DoubleAnimation Storyboard.TargetName="balltrans" Storyboard.TargetProperty="TranslateX" 
                             Duration="0:0:0.5" By="-40" FillBehavior="HoldEnd">
                <DoubleAnimation.EasingFunction>
                    <ElasticEase Oscillations="0" Springiness="1" />
                </DoubleAnimation.EasingFunction>
            </DoubleAnimation>
        </Storyboard>
        <Storyboard x:Name="ballstoryright">
            <DoubleAnimation Storyboard.TargetName="balltrans" Storyboard.TargetProperty="TranslateX" 
                             Duration="0:0:0.5" By="40" FillBehavior="HoldEnd">
                <DoubleAnimation.EasingFunction>
                    <ElasticEase Oscillations="0" Springiness="1" />
                </DoubleAnimation.EasingFunction>
            </DoubleAnimation>
        </Storyboard>
    </Page.Resources>
