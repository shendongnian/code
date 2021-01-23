    private void Button_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e) {
        DependencyObject result = null;
        VisualTreeHelper.HitTest(this,        
            (o)=> {if(GetIsHitTestTarget(o)) {
                result = o;
                return HitTestFilterBehavior.Stop;
            }
            return HitTestFilterBehavior.Continue;
            },
            (res) => HitTestResultBehavior.Stop,
            new PointHitTestParameters(e.GetPosition(this)));
    }
