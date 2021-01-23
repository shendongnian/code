                        FlowLayoutPanel flowLayoutPanel = ...; // this is the flow panel
                        Control control = ...; // this is the control you want to add in alpha order.
                        flowLayoutPanel.SuspendLayout();
                        flowLayoutPanel.Controls.Add(control);
                        // sort it alphabetically
                        for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
                        {
                            var otherControl = flowLayoutPanel.Controls[i];
                            if (otherControl != null && string.Compare(otherControl.Name, control.Name) > 0)
                            {
                                flowLayoutPanel.Controls.SetChildIndex(control, i);
                                break;
                            }
                        }
                        flowLayoutPanel.ResumeLayout();
