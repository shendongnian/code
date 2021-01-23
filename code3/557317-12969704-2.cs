    foreach (Control Cntrl in this.Pnl.Controls)
                {
                    if (Cntrl is Panel)
                    {
                        foreach (Control C in Cntrl.Controls)
                            if (C is Button)
                            {
                                C.Enabled = true;
                            }
                    }
                }
