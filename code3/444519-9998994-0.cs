    // ...
    if (RdrFlux1.Read()) {
        investigate1.Text = RdrFlux1.GetValue(0).ToString();
        if (RdrFlux1.Read()) {
            investigate2.Text = RdrFlux1.GetValue(0).ToString();
            if (RdrFlux1.Read()) {
                investigate3.Text = RdrFlux1.GetValue(0).ToString();
                if (RdrFlux1.Read()) {
                    investigate4.Text = RdrFlux1.GetValue(0).ToString();
                    if (RdrFlux1.Read())
                        investigate5.Text = RdrFlux1.GetValue(0).ToString();
                 }
            }
        }
    }
