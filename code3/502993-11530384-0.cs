    uc1.ClickPointData += new UserControl1.OnClickPointDataEvent(form_subscribe_event);
    private void form_subscribe_event(object sender, PointF[] data)
    {
        uc2.SomePublicMethod(data);
    }
