            if (nombreDeVentana != null)
            {
                panelPrincipal.Controls[nombreDeVentana].BringToFront();
            }
            if (panelPrincipal.Controls.Count > 0)
            {
                if (panelPrincipal.Controls.Cast<RadForm>().Any(radForm => radForm.WindowState != FormWindowState.Minimized))
                {
                    foreach (RadItem item in radRibbonBarGroupAbiertas.Items)
                    {
                        var buttonBorder = ((RadButtonElement) item).BorderElement;
                        if (item.Name == panelPrincipal.Controls[0].Name + "Button")
                        {
                            buttonBorder.ForeColor = Color.LimeGreen;
                            buttonBorder.BottomColor = Color.LimeGreen;
                            buttonBorder.TopColor = Color.LimeGreen;
                            buttonBorder.LeftColor = Color.LimeGreen;
                            buttonBorder.RightColor = Color.LimeGreen;
                        }
                        else
                        {
                            buttonBorder.ForeColor = Color.Transparent;
                            buttonBorder.BottomColor = Color.Transparent;
                            buttonBorder.TopColor = Color.Transparent;
                            buttonBorder.LeftColor = Color.Transparent;
                            buttonBorder.RightColor = Color.Transparent;
                        }
                    }
                }
                else
                {
                    foreach (RadItem item in radRibbonBarGroupAbiertas.Items)
                    {
                        var buttonBorder = ((RadButtonElement)item).BorderElement;
                        buttonBorder.ForeColor = Color.Transparent;
                        buttonBorder.BottomColor = Color.Transparent;
                        buttonBorder.TopColor = Color.Transparent;
                        buttonBorder.LeftColor = Color.Transparent;
                        buttonBorder.RightColor = Color.Transparent;
                    }
                }
            }
        }
