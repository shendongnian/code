    foreach (Control control in Controls)
            {
                MdiClient mdiClient = control as MdiClient;
                if (mdiClient != null)
                {
                    NonScrollableWindow nw = new NonScrollableWindow(mdiClient);
                    break;
                }
            }
