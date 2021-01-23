    static void AngleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
        Angle angleControl = (Angle)obj;
        Line line = angleControl.GetTemplateChild("PART_LINE") as Line;
            if (line!= null)
            {
                //manipulate the line here
            }
    }
