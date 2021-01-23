        foreach (Control c in EnumerateControlsRecursive(Page))
        {
            if(c is BoldGauge)
            {
                BoldGauge.GaugeValue = "some value"
            }
        }
