            private bool recursing;
            private void toolTip1_Popup(object sender, PopupEventArgs e)
            {
                Control c = e.AssociatedControl as Control;
                if (c != null)
                {
                    if (!recursing)
                    {
                        recursing = true;
                        toolTip1.SetToolTip(c, "totototo");
                        recursing = false;
                    }
                }
            }
